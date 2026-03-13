namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapErrorTestsTaskLeft : MapErrorTestsBase
{
    [Test]
    public async Task MapErrorAsyncTaskLeftReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = SucceededResult();

        var output = await Task.FromResult(result).MapErrorAsync(MapErrorFunc);

        AssertUnchanged(result, output);
    }

    [Test]
    public async Task MapErrorAsyncTaskLeftMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await Task.FromResult(FailedResult()).MapErrorAsync(MapErrorFunc);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncTaskLeftTMapsAllErrorsAndPreservesSuccesses()
    {
        var output = await Task.FromResult(FailedResultT()).MapErrorAsync(MapErrorFunc);

        AssertMapped(output);
    }
}
