namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTryTestsTaskRight : TapTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncExecutesTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = await result.TapTryAsync(TaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncTExecutesTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = await result.TapTryAsync(TaskActionWithValueAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }
}
