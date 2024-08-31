namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsTaskLeft : BindTestsBase
{
    [Fact]
    public async Task BindTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailure().BindAsync(Success);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskLeftSelectsNewResult()
    {
        var output = await TaskSuccess().BindAsync(Success);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskLeftTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailureT<string>().BindAsync(SuccessT);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskLeftTSelectsNewResult()
    {
        var output = await TaskSuccessT(Value).BindAsync(SuccessT);
        AssertSuccess(output);
    }
}
