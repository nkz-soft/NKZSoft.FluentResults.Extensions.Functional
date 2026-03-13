namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapErrorTestsTaskRight : MapErrorTestsBase
{
    [Test]
    public async Task MapErrorAsyncTaskRightReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = SucceededResult();

        var output = await result.MapErrorAsync(TaskMapErrorFuncAsync);

        AssertUnchanged(result, output);
    }

    [Test]
    public async Task MapErrorAsyncTaskRightMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await FailedResult().MapErrorAsync(TaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncTaskRightTMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await FailedResultT().MapErrorAsync(TaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncTaskRightThrowsWhenMapperIsNull()
    {
        var action = () => Result.Ok().MapErrorAsync((Func<IError, Task<IError>>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
