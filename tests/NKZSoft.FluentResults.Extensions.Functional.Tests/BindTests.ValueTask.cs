namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsValueTask : BindTestsBase
{
    [Fact]
    public async Task BindValueTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await BindTestsBase.ValueTaskFailure().BindAsync(ValueTaskSuccess);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindValueTaskSelectsNewResult()
    {
        var output = await ValueTaskSuccess().BindAsync(ValueTaskSuccess);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindValueTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await BindTestsBase.ValueTaskFailureT<string>().BindAsync(ValueTaskSuccessT);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindValueTaskReturnsNewResult()
    {
        var output = await ValueTaskSuccessT(Value).BindAsync(ValueTaskSuccessT);
        AssertSuccess(output);
    }
}
