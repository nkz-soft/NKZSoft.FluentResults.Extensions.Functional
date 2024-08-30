namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsValueTaskLeft : BindTestsBase
{
    [Fact]
    public async Task BindValueTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await BindTestsBase.ValueTaskFailure().BindAsync(Success);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindValueTaskLeftSelectsNewResult()
    {
        var output = await ValueTaskSuccess().BindAsync(Success);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindValueTaskLeftTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await BindTestsBase.ValueTaskFailureT<string>().BindAsync(SuccessT);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindValueTaskLeftTSelectsNewResult()
    {
        var output = await ValueTaskSuccessT(Value).BindAsync(SuccessT);
        AssertSuccess(output);
    }
}
