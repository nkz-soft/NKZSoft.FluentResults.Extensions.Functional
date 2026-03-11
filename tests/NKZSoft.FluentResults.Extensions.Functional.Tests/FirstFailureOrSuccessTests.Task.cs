namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FirstFailureOrSuccessTestsTask
{
    [Test]
    public async Task FirstFailureOrSuccessAsyncTaskReturnsFirstFailedResult()
    {
        var firstFailure = Result.Fail("Failure 1");
        var secondFailure = Result.Fail("Failure 2");

        var output = await ResultExtensions.FirstFailureOrSuccessAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(firstFailure),
            Task.FromResult(secondFailure));

        output.IsFailed.Should().BeTrue();
        output.Should().BeSameAs(firstFailure);
        output.Errors.Should().ContainSingle(error => error.Message == "Failure 1");
    }

    [Test]
    public async Task FirstFailureOrSuccessAsyncTaskReturnsSuccessWhenAllAreSuccessful()
    {
        var output = await ResultExtensions.FirstFailureOrSuccessAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task FirstFailureOrSuccessAsyncTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.FirstFailureOrSuccessAsync(Array.Empty<Task<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task FirstFailureOrSuccessAsyncTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.FirstFailureOrSuccessAsync((Task<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task FirstFailureOrSuccessAsyncTaskThrowsWhenResultTaskItemIsNull()
    {
        Task<Result>[] inputs = [Task.FromResult(Result.Ok()), null!, Task.FromResult(Result.Fail("Failure"))];

        var action = async () => await ResultExtensions.FirstFailureOrSuccessAsync(inputs);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
