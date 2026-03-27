namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapParallelTestsValueTask
{
    [Test]
    public async Task MapParallelAsyncValueTaskPreservesInputOrder()
    {
        var input = new[] { 1, 2, 3 };

        Func<int, ValueTask<Result<int>>> mapper = async value =>
        {
            await Task.Delay(value == 1 ? 50 : 5);
            return Result.Ok(value * 10);
        };

        var output = await input.MapParallelAsync(mapper);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(10, 20, 30);
    }

    [Test]
    public async Task MapParallelAsyncValueTaskAggregatesFailures()
    {
        var input = new[] { 1, 2, 3 };

        Func<int, ValueTask<Result<int>>> mapper = value =>
            ValueTask.FromResult(value == 2 ? Result.Fail<int>("boom") : Result.Ok(value));

        var output = await input.MapParallelAsync(mapper);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == "boom");
    }
}
