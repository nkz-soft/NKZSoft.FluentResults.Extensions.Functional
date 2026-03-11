namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTestsTask : BindTestsBase
{
    [Test]
    public async Task BindTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().BindAsync(TaskOkFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindTaskSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().BindAsync(TaskOkFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task BindTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().BindAsync(TaskOkTFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindTaskTSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().BindAsync(TaskOkTFuncAsync);
        AssertSuccess(output);
    }
}
