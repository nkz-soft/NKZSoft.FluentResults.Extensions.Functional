namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTryTestsTaskLeft : TapIfTryTestsBase
{
    [Test]
    public async Task TapIfTryAsyncExecutesActionWhenConditionTrue()
    {
        var resultTask = Task.FromResult(Result.Ok());

        var output = await resultTask.TapIfTryAsync(true, ActionEmpty);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: true);
    }

    [Test]
    public async Task TapIfTryAsyncConvertsExceptionToFailureWithCustomError()
    {
        var resultTask = Task.FromResult(Result.Ok());

        var output = await resultTask.TapIfTryAsync(true, ThrowAction, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }
}
