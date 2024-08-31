namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsTask : BindTestsBase
{
    [Fact]
    public async Task BindTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await BindTestsBase.TaskFailure().BindAsync(TaskSuccess);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskSelectsNewResult()
    {
        var output = await TaskSuccess().BindAsync(TaskSuccess);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await BindTestsBase.TaskFailureT<string>().BindAsync(TaskSuccessT);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskTSelectsNewResult()
    {
        var output = await TaskSuccessT(Value).BindAsync(TaskSuccessT);
        AssertSuccess(output);
    }
}
