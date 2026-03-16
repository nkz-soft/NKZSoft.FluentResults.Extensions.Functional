namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTryTestsTask : TapTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncExecutesTaskFunctionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();

        var output = await resultTask.TapTryAsync(TaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncTExecutesTaskFunctionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();

        var output = await resultTask.TapTryAsync(TaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    public async Task TapTryAsyncConvertsTaskExceptionToFailureWithDefaultError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .TapTryAsync(ThrowTaskActionAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task TapTryAsyncConvertsTaskExceptionToFailureWithCustomError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .TapTryAsync(ThrowTaskActionAsync, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }
}
