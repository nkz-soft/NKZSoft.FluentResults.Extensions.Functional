namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CombineTestsTask
{
    [Test]
    public async Task CombineAsyncTaskReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CombineAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineAsyncTaskAggregatesErrorsFromAllFailedResults()
    {
        var output = await ResultExtensions.CombineAsync(
            Task.FromResult(Result.Fail("Failure 1")),
            Task.FromResult(Result.Fail("Failure 2")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public async Task CombineAsyncTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.CombineAsync(Array.Empty<Task<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineAsyncTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.CombineAsync((Task<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CombineAsyncTaskThrowsWhenTaskItemIsNull()
    {
        Task<Result>[] inputs = [Task.FromResult(Result.Ok()), null!];

        var action = async () => await ResultExtensions.CombineAsync(inputs);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CombineAsyncTaskTReturnsMergedValuesWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CombineAsync(
            Task.FromResult(Result.Ok(1)),
            Task.FromResult(Result.Ok(2)));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public async Task CombineAsyncTaskTReturnsFailureAndAggregatesErrors()
    {
        var output = await ResultExtensions.CombineAsync(
            Task.FromResult(Result.Ok(1)),
            Task.FromResult(Result.Fail<int>("Failure")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(e => e.Message == "Failure");
    }
}
