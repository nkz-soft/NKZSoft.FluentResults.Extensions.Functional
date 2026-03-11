namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTestsTask : TapTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.TapAsync(TaskActionTAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapExecutesValueTaskActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.TapAsync(ValueTaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesValueTaskActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.TapAsync(ValueTaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesValueTaskActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.TapAsync(ValueTaskActionTAsync);

        AssertSuccess(output, isSuccess);
    }
}
