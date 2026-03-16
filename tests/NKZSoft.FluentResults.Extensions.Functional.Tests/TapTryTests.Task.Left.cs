namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTryTestsTaskLeft : TapTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncExecutesActionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = Task.FromResult(Result.OkIf(isSuccess, ErrorMessage));

        var output = await resultTask.TapTryAsync(ActionEmpty);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    public async Task TapTryAsyncConvertsExceptionToFailureWithCustomError()
    {
        var resultTask = Task.FromResult(Result.Ok());

        var output = await resultTask.TapTryAsync(ThrowAction, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }
}
