namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapErrorTestsValueTaskLeft : MapErrorTestsBase
{
    [Test]
    public async Task MapErrorAsyncValueTaskLeftReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = SucceededResult();

        var output = await ValueTask.FromResult(result).MapErrorAsync(MapErrorFunc);

        AssertUnchanged(result, output);
    }

    [Test]
    public async Task MapErrorAsyncValueTaskLeftMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await ValueTask.FromResult(FailedResult()).MapErrorAsync(MapErrorFunc);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncValueTaskLeftTMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await ValueTask.FromResult(FailedResultT()).MapErrorAsync(MapErrorFunc);

        AssertMapped(output);
    }
}
