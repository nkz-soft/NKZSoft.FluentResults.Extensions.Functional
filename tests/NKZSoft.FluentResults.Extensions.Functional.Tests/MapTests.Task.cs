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
}
