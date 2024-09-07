namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTestsTask : BindTestsBase
{
    [Fact]
    public async Task BindTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().BindAsync(TaskOkFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().BindAsync(TaskOkFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().BindAsync(TaskOkTFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskTSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().BindAsync(TaskOkTFuncAsync);
        AssertSuccess(output);
    }
}
