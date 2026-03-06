namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTestsTask : MapTestsBase
{
    [Fact]
    public async Task MapTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapTaskSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task MapTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapTaskTSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task MapTaskWithValueTaskFuncReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapTaskWithValueTaskFuncSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task MapTaskTWithValueTaskFuncReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapTaskTWithValueTaskFuncSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }
}
