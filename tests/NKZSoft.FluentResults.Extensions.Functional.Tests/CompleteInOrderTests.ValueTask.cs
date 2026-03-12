namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompleteInOrderTestsValueTask
{
    [Test]
    public async Task CompleteInOrderAsyncValueTaskReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            new ValueTask<Result>(Result.Ok()),
            new ValueTask<Result>(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompleteInOrderAsyncValueTaskAggregatesErrorsFromAllFailedResults()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            new ValueTask<Result>(Result.Fail("Failure 1")),
            new ValueTask<Result>(Result.Fail("Failure 2")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public async Task CompleteInOrderAsyncValueTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(Array.Empty<ValueTask<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompleteInOrderAsyncValueTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.CompleteInOrderAsync((ValueTask<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CompleteInOrderAsyncValueTaskTReturnsMergedValuesWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            new ValueTask<Result<int>>(Result.Ok(1)),
            new ValueTask<Result<int>>(Result.Ok(2)));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public async Task CompleteInOrderAsyncValueTaskTReturnsFailureAndAggregatesErrors()
    {
        var output = await ResultExtensions.CompleteInOrderAsync(
            new ValueTask<Result<int>>(Result.Ok(1)),
            new ValueTask<Result<int>>(Result.Fail<int>("Failure")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(e => e.Message == "Failure");
    }
}
