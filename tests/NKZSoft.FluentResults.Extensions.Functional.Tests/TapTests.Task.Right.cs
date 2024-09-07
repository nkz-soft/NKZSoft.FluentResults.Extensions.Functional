namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTestsTaskRight : TapTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapTExecutesActionOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(TaskActionEmptyAsync);

        AssertSuccess(output, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TapTExecutesActionTOnResultSuccessAndReturnsSelf(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.TapAsync(TaskActionTAsync);

        AssertSuccess(output, isSuccess);
    }
}
