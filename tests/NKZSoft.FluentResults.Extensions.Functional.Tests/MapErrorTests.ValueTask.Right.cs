namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapErrorTestsValueTaskRight : MapErrorTestsBase
{
    [Test]
    public async Task MapErrorAsyncValueTaskRightReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = SucceededResult();

        var output = await result.MapErrorAsync(ValueTaskMapErrorFuncAsync);

        AssertUnchanged(result, output);
    }

    [Test]
    public async Task MapErrorAsyncValueTaskRightMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await FailedResult().MapErrorAsync(ValueTaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncValueTaskRightTMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await FailedResultT().MapErrorAsync(ValueTaskMapErrorFuncAsync);

        AssertMapped(output);
    }
}
