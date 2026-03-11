namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTestsValueTask : TapTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.TapAsync(ValueTaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(ValueTaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(ValueTaskActionTAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapExecutesTaskActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesTaskActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesTaskActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(TaskActionTAsync);

        AssertSuccess(output, isSuccess);
    }
}
