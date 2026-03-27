namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapParallelTestsTask
{
    [Test]
    public async Task MapParallelAsyncTaskPreservesInputOrder()
    {
        var input = new[] { 1, 2, 3 };

        Func<int, Task<Result<int>>> mapper = async value =>
        {
            await Task.Delay(value == 1 ? 50 : 5);
            return Result.Ok(value * 10);
        };

        var output = await input.MapParallelAsync(mapper);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(10, 20, 30);
    }

    [Test]
    public async Task MapParallelAsyncTaskAggregatesFailures()
    {
        var input = new[] { 1, 2, 3 };

        Func<int, Task<Result<int>>> mapper = value =>
            Task.FromResult(value == 2 ? Result.Fail<int>("boom") : Result.Ok(value));

        var output = await input.MapParallelAsync(mapper);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == "boom");
    }

    [Test]
    public async Task MapParallelAsyncTaskThrowsWhenMapperIsNull()
    {
        var action = async () => await new[] { 1 }.MapParallelAsync<int, int>((Func<int, Task<Result<int>>>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task MapParallelAsyncTaskThrowsWhenMapperThrows()
    {
        Func<int, Task<Result<int>>> mapper = value => value == 1
            ? Task.FromException<Result<int>>(new InvalidOperationException("first"))
            : Task.FromException<Result<int>>(new ArgumentException("second"));

        var action = async () => await new[] { 1, 2 }.MapParallelAsync(mapper);

        var exception = await action.Should().ThrowAsync<AggregateException>();
        exception.Which.InnerExceptions[0].Message.Should().Be("first");
        exception.Which.InnerExceptions[1].Message.Should().Be("second");
    }

    [Test]
    public async Task MapParallelAsyncTaskCancellationStopsSchedulingNewWork()
    {
        var source = Enumerable.Range(1, 10).ToArray();
        var cts = new CancellationTokenSource();
        var started = 0;

        Func<int, CancellationToken, Task<Result<int>>> mapper = async (value, token) =>
        {
            var index = Interlocked.Increment(ref started);
            if (index == 1)
            {
                cts.Cancel();
            }

            await Task.Delay(20, token);
            return Result.Ok(value);
        };

        var action = async () => await source.MapParallelAsync(
            mapper,
            maxDegreeOfParallelism: 1,
            cancellationToken: cts.Token);

        await action.Should().ThrowAsync<OperationCanceledException>();
        started.Should().Be(1);
    }
}
