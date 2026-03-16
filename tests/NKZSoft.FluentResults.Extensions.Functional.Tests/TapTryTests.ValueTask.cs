namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTryTestsValueTask : TapTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncExecutesValueTaskFunctionOnlyWhenValueTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);

        var output = await resultTask.TapTryAsync(ValueTaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncTExecutesValueTaskFunctionOnlyWhenValueTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);

        var output = await resultTask.TapTryAsync(ValueTaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    public async Task TapTryAsyncConvertsValueTaskExceptionToFailureWithDefaultError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .TapTryAsync(ThrowValueTaskActionAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }
}
