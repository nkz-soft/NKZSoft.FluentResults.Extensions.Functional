namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTestsValueTask : BindTestsBase
{
    [Test]
    public async Task BindValueTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().BindAsync(ValueTaskOkFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindValueTaskSelectsNewResult()
    {
        var output = await Common.TestBase.ValueTaskOkResultAsync().BindAsync(ValueTaskOkFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task BindValueTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultTAsync().BindAsync(ValueTaskOkTFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindValueTaskReturnsNewResult()
    {
        var output = await Common.TestBase.ValueTaskOkResultTAsync().BindAsync(ValueTaskOkTFuncAsync);
        AssertSuccess(output);
    }
}
