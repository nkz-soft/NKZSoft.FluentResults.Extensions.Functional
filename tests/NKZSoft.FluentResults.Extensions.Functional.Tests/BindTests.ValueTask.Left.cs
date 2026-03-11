namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsValueTaskLeft : BindTestsBase
{
    [Test]
    public async Task BindValueTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().BindAsync(OkFunc);
        AssertFailure(output);
    }

    [Test]
    public async Task BindValueTaskLeftSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().BindAsync(OkTFunc);
        AssertSuccess(output);
    }

    [Test]
    public async Task BindValueTaskLeftTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultTAsync().BindAsync(OkTFunc);
        AssertFailure(output);
    }

    [Test]
    public async Task BindValueTaskLeftTSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().BindAsync(OkTFunc);
        AssertSuccess(output);
    }
}
