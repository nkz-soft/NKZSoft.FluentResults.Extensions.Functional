namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsValueTaskLeft : BindTestsBase
{
    [Fact]
    public async Task BindValueTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().BindAsync(OkFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindValueTaskLeftSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().BindAsync(OkTFunc);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindValueTaskLeftTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultTAsync().BindAsync(OkTFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindValueTaskLeftTSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().BindAsync(OkTFunc);
        AssertSuccess(output);
    }
}
