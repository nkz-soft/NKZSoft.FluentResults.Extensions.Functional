namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTestsValueTask : MapTestsBase
{
    [Test]
    public async Task MapValueTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapValueTaskSelectsNewResult()
    {
        var output = await Common.TestBase.ValueTaskOkResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapValueTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapValueTaskTSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapValueTaskWithTaskFuncReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapValueTaskWithTaskFuncSelectsNewResult()
    {
        var output = await Common.TestBase.ValueTaskOkResultAsync().MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapValueTaskTWithTaskFuncReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultTAsync().MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task MapValueTaskTWithTaskFuncSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }
}
