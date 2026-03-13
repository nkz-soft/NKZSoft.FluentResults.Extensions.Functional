namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapErrorTestsTask : MapErrorTestsBase
{
    [Test]
    public async Task MapErrorAsyncTaskMapsAllErrorsWithTaskMapper()
    {
        var output = await Task.FromResult(FailedResult()).MapErrorAsync(TaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncTaskMapsAllErrorsWithValueTaskMapper()
    {
        var output = await Task.FromResult(FailedResult()).MapErrorAsync(ValueTaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncTaskTMapsAllErrorsWithTaskMapper()
    {
        var output = await Task.FromResult(FailedResultT()).MapErrorAsync(TaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncTaskTMapsAllErrorsWithValueTaskMapper()
    {
        var output = await Task.FromResult(FailedResultT()).MapErrorAsync(ValueTaskMapErrorFuncAsync);

        AssertMapped(output);
    }
}
