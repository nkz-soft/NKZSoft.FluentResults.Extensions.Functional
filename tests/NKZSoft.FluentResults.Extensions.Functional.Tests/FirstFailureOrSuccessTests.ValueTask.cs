namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FirstFailureOrSuccessTestsValueTask
{
    [Fact]
    public async Task FirstFailureOrSuccessAsyncValueTaskReturnsFirstFailedResult()
    {
        var firstFailure = Result.Fail("Failure 1");
        var secondFailure = Result.Fail("Failure 2");

        var output = await ResultExtensions.FirstFailureOrSuccessAsync(
            new ValueTask<Result>(Result.Ok()),
            new ValueTask<Result>(firstFailure),
            new ValueTask<Result>(secondFailure));

        output.IsFailed.Should().BeTrue();
        output.Should().BeSameAs(firstFailure);
        output.Errors.Should().ContainSingle(error => error.Message == "Failure 1");
    }

    [Fact]
    public async Task FirstFailureOrSuccessAsyncValueTaskReturnsSuccessWhenAllAreSuccessful()
    {
        var output = await ResultExtensions.FirstFailureOrSuccessAsync(
            new ValueTask<Result>(Result.Ok()),
            new ValueTask<Result>(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task FirstFailureOrSuccessAsyncValueTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.FirstFailureOrSuccessAsync(Array.Empty<ValueTask<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task FirstFailureOrSuccessAsyncValueTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.FirstFailureOrSuccessAsync((ValueTask<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
