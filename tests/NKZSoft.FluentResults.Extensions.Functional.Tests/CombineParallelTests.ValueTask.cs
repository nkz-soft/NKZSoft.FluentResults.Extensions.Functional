namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CombineParallelTestsValueTask
{
    [Test]
    public async Task CombineParallelAsyncValueTaskReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = await ResultExtensions.CombineParallelAsync(
            new ValueTask<Result>(Result.Ok()),
            new ValueTask<Result>(Result.Ok()));

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineParallelAsyncValueTaskAggregatesErrorsFromAllFailedResults()
    {
        var output = await ResultExtensions.CombineParallelAsync(
            new ValueTask<Result>(Result.Fail("Failure 1")),
            new ValueTask<Result>(Result.Fail("Failure 2")));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public async Task CombineParallelAsyncValueTaskTReturnsValuesInInputOrder()
    {
        var output = await ResultExtensions.CombineParallelAsync(
            new ValueTask<Result<int>>(Task.Run(async () =>
            {
                await Task.Delay(40);
                return Result.Ok(1);
            })),
            new ValueTask<Result<int>>(Task.Run(async () =>
            {
                await Task.Delay(5);
                return Result.Ok(2);
            })));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public async Task CombineParallelAsyncValueTaskReturnsSuccessWhenNoResultsProvided()
    {
        var output = await ResultExtensions.CombineParallelAsync(Array.Empty<ValueTask<Result>>());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineParallelAsyncValueTaskThrowsWhenResultsArrayIsNull()
    {
        var action = async () => await ResultExtensions.CombineParallelAsync((ValueTask<Result>[])null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task CombineParallelAsyncValueTaskThrowsWhenMaxDegreeIsInvalid()
    {
        var action = async () => await ResultExtensions.CombineParallelAsync([new ValueTask<Result>(Result.Ok())], 0);

        await action.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }
}
