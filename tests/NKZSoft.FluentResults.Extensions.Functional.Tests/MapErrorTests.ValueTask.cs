namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapErrorTestsValueTask : MapErrorTestsBase
{
    [Test]
    public async Task MapErrorAsyncValueTaskMapsAllErrorsWithValueTaskMapper()
    {
        var output = await ValueTask.FromResult(FailedResult()).MapErrorAsync(ValueTaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncValueTaskMapsAllErrorsWithTaskMapper()
    {
        var output = await ValueTask.FromResult(FailedResult()).MapErrorAsync(TaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncValueTaskTMapsAllErrorsWithValueTaskMapper()
    {
        var output = await ValueTask.FromResult(FailedResultT()).MapErrorAsync(ValueTaskMapErrorFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapErrorAsyncValueTaskTMapsAllErrorsWithTaskMapper()
    {
        var output = await ValueTask.FromResult(FailedResultT()).MapErrorAsync(TaskMapErrorFuncAsync);

        AssertMapped(output);
    }
}
