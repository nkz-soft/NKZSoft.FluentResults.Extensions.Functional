namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTryTestsTask : TapIfTryTestsBase
{
    [Test]
    public async Task TapIfTryAsyncExecutesTaskWhenConditionTrue()
    {
        var resultTask = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();

        var output = await resultTask.TapIfTryAsync(true, TaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: true);
    }

    [Test]
    public async Task TapIfTryAsyncSkipsTaskWhenConditionFalse()
    {
        var resultTask = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();

        var output = await resultTask.TapIfTryAsync(false, TaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: false, expectedSuccess: true);
    }

    [Test]
    public async Task TapIfTryAsyncConvertsTaskExceptionToFailureWithDefaultError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .TapIfTryAsync(true, ThrowTaskActionAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task TapIfTryAsyncConvertsTaskExceptionToFailureWithCustomError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .TapIfTryAsync(true, ThrowTaskActionAsync, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }
}
