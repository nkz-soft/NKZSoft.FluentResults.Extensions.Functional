namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class TapTestsValueTaskLeft : TapTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.TapAsync(ActionEmpty);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapTExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(ActionEmpty);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapTExecutesActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(ActionT);

        AssertSuccess(output, isSuccess);
    }
}
