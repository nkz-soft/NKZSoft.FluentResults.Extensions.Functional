namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompleteInOrderTestsTask
{
    [Test]
    public async Task CompleteInOrderAsyncTaskReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompleteInOrderAsyncTaskAggregatesErrorsFromAllFailedResults()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            Task.FromResult(Result.Fail("Failure 1")),
            Task.FromResult(Result.Fail("Failure 2")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public async Task CompleteInOrderAsyncTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(Array.Empty<Task<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompleteInOrderAsyncTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.CompleteInOrderAsync((Task<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CompleteInOrderAsyncTaskThrowsWhenTaskItemIsNull()
    {
        Task<Result>[] inputs = [Task.FromResult(Result.Ok()), null!];

        var action = async () => await ResultExtensions.CompleteInOrderAsync(inputs);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CompleteInOrderAsyncTaskTReturnsMergedValuesWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            Task.FromResult(Result.Ok(1)),
            Task.FromResult(Result.Ok(2)));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public async Task CompleteInOrderAsyncTaskTReturnsFailureAndAggregatesErrors()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            Task.FromResult(Result.Ok(1)),
            Task.FromResult(Result.Fail<int>("Failure")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(e => e.Message == "Failure");
    }

    [Test]
    public async Task CompleteInOrderAsyncTaskHasParityWithValueTaskForFailures()
    {
        var taskOutput = await ResultExtensions.CompleteInOrderAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Fail("Failure")));

        var valueTaskOutput = await ResultExtensions.CompleteInOrderAsync(
            new ValueTask<Result>(Result.Ok()),
            new ValueTask<Result>(Result.Fail("Failure")));

        Common.TestBase.AssertResultParity(taskOutput, valueTaskOutput);
    }
}
