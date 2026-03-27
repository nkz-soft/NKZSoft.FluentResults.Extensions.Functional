namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CombineParallelTestsTask
{
    [Test]
    public async Task CombineParallelAsyncTaskReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CombineParallelAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineParallelAsyncTaskAggregatesErrorsFromAllFailedResults()
    {
        var output = await ResultExtensions.CombineParallelAsync(
            Task.FromResult(Result.Fail("Failure 1")),
            Task.FromResult(Result.Fail("Failure 2")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public async Task CombineParallelAsyncTaskTReturnsValuesInInputOrder()
    {
        var first = new TaskCompletionSource<Result<int>>(TaskCreationOptions.RunContinuationsAsynchronously);
        var second = new TaskCompletionSource<Result<int>>(TaskCreationOptions.RunContinuationsAsynchronously);

        var running = ResultExtensions.CombineParallelAsync([first.Task, second.Task]);

        second.SetResult(Result.Ok(2));
        first.SetResult(Result.Ok(1));

        var output = await running;

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public async Task CombineParallelAsyncTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.CombineParallelAsync(Array.Empty<Task<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineParallelAsyncTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.CombineParallelAsync((Task<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CombineParallelAsyncTaskThrowsWhenTaskItemIsNull()
    {
        Task<Result>[] inputs = [Task.FromResult(Result.Ok()), null!];

        var action = async () => await ResultExtensions.CombineParallelAsync(inputs);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CombineParallelAsyncTaskThrowsWhenMaxDegreeIsInvalid()
    {
        var action = async () => await ResultExtensions.CombineParallelAsync([Task.FromResult(Result.Ok())], 0);

        await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Test]
    public async Task CombineParallelAsyncTaskThrowsAggregateExceptionWithInputOrderedInnerExceptions()
    {
        static async Task<Result> Throwing(string message, int delay)
        {
            await Task.Delay(delay);
            throw message == "first"
                ? new InvalidOperationException(message)
                : new ArgumentException(message);
        }

        var first = Throwing("first", 40);
        var second = Throwing("second", 5);

        var action = async () => await ResultExtensions.CombineParallelAsync([first, second]);

        var exception = await action.Should().ThrowAsync<AggregateException>();
        exception.Which.InnerExceptions.Should().HaveCount(2);
        exception.Which.InnerExceptions[0].Message.Should().Be("first");
        exception.Which.InnerExceptions[1].Message.Should().Be("second");
    }
}
