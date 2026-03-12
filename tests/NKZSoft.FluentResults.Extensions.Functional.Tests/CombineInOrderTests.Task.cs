namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CombineInOrderTestsTask
{
    [Test]
    public async Task CombineInOrderAsyncTaskReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CombineInOrderAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineInOrderAsyncTaskAggregatesErrorsFromAllFailedResults()
    {
        var output = await ResultExtensions.CombineInOrderAsync(
            Task.FromResult(Result.Fail("Failure 1")),
            Task.FromResult(Result.Fail("Failure 2")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public async Task CombineInOrderAsyncTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.CombineInOrderAsync(Array.Empty<Task<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineInOrderAsyncTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.CombineInOrderAsync((Task<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CombineInOrderAsyncTaskThrowsWhenTaskItemIsNull()
    {
        Task<Result>[] inputs = [Task.FromResult(Result.Ok()), null!];

        var action = async () => await ResultExtensions.CombineInOrderAsync(inputs);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CombineInOrderAsyncTaskTReturnsMergedValuesWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CombineInOrderAsync(
            Task.FromResult(Result.Ok(1)),
            Task.FromResult(Result.Ok(2)));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public async Task CombineInOrderAsyncTaskTReturnsFailureAndAggregatesErrors()
    {
        var output = await ResultExtensions.CombineInOrderAsync(
            Task.FromResult(Result.Ok(1)),
            Task.FromResult(Result.Fail<int>("Failure")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(e => e.Message == "Failure");
    }
}
