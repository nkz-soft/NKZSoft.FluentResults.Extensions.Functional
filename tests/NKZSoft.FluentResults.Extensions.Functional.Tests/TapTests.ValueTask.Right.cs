namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class TapTestsValueTaskRight : TapTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.TapAsync(ValueTaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(ValueTaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTExecutesActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(ValueTaskActionTAsync);

        AssertSuccess(output, isSuccess);
    }
}
