namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompleteParallelTestsValueTask
{
    [Test]
    public async Task CompleteParallelAsyncValueTaskReturnsSameOutputAsCombineParallelAsync()
    {
        var complete = await ResultExtensions.CompleteParallelAsync(
            new ValueTask<Result>(Result.Ok()),
            new ValueTask<Result>(Result.Fail("Failure")));
        var combine = await ResultExtensions.CombineParallelAsync(
            new ValueTask<Result>(Result.Ok()),
            new ValueTask<Result>(Result.Fail("Failure")));

        complete.IsFailed.Should().BeTrue();
        complete.Errors.Should().HaveCount(combine.Errors.Count);
    }

    [Test]
    public async Task CompleteParallelAsyncValueTaskTReturnsMergedValues()
    {
        var output = await ResultExtensions.CompleteParallelAsync(
            new ValueTask<Result<int>>(Result.Ok(1)),
            new ValueTask<Result<int>>(Result.Ok(2)));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }
}
