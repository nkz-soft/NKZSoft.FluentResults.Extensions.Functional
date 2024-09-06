namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsTaskLeft : BindTestsBase
{
    [Fact]
    public async Task BindTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().BindAsync(OkFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskLeftSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().BindAsync(OkFunc);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskLeftTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().BindAsync(OkTFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskLeftTSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().BindAsync(OkTFunc);
        AssertSuccess(output);
    }
}
