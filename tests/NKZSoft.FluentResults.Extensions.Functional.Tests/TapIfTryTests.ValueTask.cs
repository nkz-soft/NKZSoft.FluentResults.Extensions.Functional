namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTryTestsValueTask : TapIfTryTestsBase
{
    [Test]
    public async Task TapIfTryAsyncExecutesValueTaskWhenConditionTrue()
    {
        var resultTask = ResultExtensions.OkIfAsync(true, ErrorMessage);

        var output = await resultTask.TapIfTryAsync(true, ValueTaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: true);
    }

    [Test]
    public async Task TapIfTryAsyncSkipsValueTaskWhenConditionFalse()
    {
        var resultTask = ResultExtensions.OkIfAsync(true, ErrorMessage);

        var output = await resultTask.TapIfTryAsync(false, ValueTaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: false, expectedSuccess: true);
    }

    [Test]
    public async Task TapIfTryAsyncConvertsValueTaskExceptionToFailureWithDefaultError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .TapIfTryAsync(true, ThrowValueTaskActionAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }
}
