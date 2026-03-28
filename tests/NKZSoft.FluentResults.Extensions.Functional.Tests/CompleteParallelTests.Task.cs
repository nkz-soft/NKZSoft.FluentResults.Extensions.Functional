namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompleteParallelTestsTask
{
    [Test]
    public async Task CompleteParallelAsyncTaskReturnsSameOutputAsCombineParallelAsync()
    {
        var complete = await ResultExtensions.CompleteParallelAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Fail("Failure")));
        var combine = await ResultExtensions.CombineParallelAsync(
            Task.FromResult(Result.Ok()),
            Task.FromResult(Result.Fail("Failure")));

        complete.IsFailed.Should().BeTrue();
        complete.Errors.Should().HaveCount(combine.Errors.Count);
    }

    [Test]
    public async Task CompleteParallelAsyncTaskTReturnsMergedValues()
    {
        var output = await ResultExtensions.CompleteParallelAsync(
            Task.FromResult(Result.Ok(1)),
            Task.FromResult(Result.Ok(2)));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public async Task CompleteParallelAsyncTaskThrowsWhenCancellationIsPreRequested()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var action = async () => await ResultExtensions.CompleteParallelAsync(
            [Task.FromResult(Result.Ok())],
            cancellationToken: cts.Token);

        await action.Should().ThrowAsync<OperationCanceledException>();
    }
}
