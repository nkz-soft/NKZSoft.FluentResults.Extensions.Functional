namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTryTestsValueTaskRight : TapTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncExecutesValueTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = await result.TapTryAsync(ValueTaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncTExecutesValueTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = await result.TapTryAsync(ValueTaskActionWithValueAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }
}
