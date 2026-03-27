namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TraverseParallelTestsValueTask
{
    [Test]
    public async Task TraverseParallelAsyncValueTaskPreservesInputOrder()
    {
        var input = new[] { 1, 2, 3 };

        Func<int, ValueTask<Result<int>>> traverse = async value =>
        {
            await Task.Delay(value == 1 ? 40 : 5);
            return Result.Ok(value + 1);
        };

        var output = await input.TraverseParallelAsync(traverse);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(2, 3, 4);
    }

    [Test]
    public async Task TraverseParallelAsyncValueTaskAggregatesFailures()
    {
        var input = new[] { 1, 2, 3 };

        Func<int, ValueTask<Result<int>>> traverse = value =>
            ValueTask.FromResult(value == 2 ? Result.Fail<int>("boom") : Result.Ok(value));

        var output = await input.TraverseParallelAsync(traverse);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == "boom");
    }
}
