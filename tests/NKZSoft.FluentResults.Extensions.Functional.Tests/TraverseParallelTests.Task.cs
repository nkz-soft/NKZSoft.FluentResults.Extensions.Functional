namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TraverseParallelTestsTask
{
    [Test]
    public async Task TraverseParallelAsyncTaskPreservesInputOrder()
    {
        var input = new[] { 1, 2, 3 };

        Func<int, Task<Result<int>>> traverse = async value =>
        {
            await Task.Delay(value == 1 ? 40 : 5);
            return Result.Ok(value + 1);
        };

        var output = await input.TraverseParallelAsync(traverse);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(2, 3, 4);
    }

    [Test]
    public async Task TraverseParallelAsyncTaskThrowsWhenValuesIsNull()
    {
        IEnumerable<int>? input = null;
        Func<int, Task<Result<int>>> traverse = value => Task.FromResult(Result.Ok(value));
        var action = async () => await input!.TraverseParallelAsync(traverse);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
