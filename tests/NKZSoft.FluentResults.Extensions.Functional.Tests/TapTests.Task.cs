namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTestsTask : TapTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapTExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapTExecutesActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.TapAsync(TaskActionTAsync);

        AssertSuccess(output, isSuccess);
    }
}
