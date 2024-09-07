namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTests : TapTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TapExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = result.Tap(ActionEmpty);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TapTExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = result.Tap(ActionEmpty);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TapTExecutesActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = result.Tap(ActionT);

        AssertSuccess(output, isSuccess);
    }
}
