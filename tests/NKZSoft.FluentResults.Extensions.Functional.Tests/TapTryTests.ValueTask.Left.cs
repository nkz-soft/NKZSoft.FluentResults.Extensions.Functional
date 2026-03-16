namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTryTestsValueTaskLeft : TapTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapTryAsyncExecutesActionOnlyWhenValueTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = new ValueTask<Result>(Result.OkIf(isSuccess, ErrorMessage));

        var output = await resultTask.TapTryAsync(ActionEmpty);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    public async Task TapTryAsyncConvertsExceptionToFailureWithCustomError()
    {
        var resultTask = new ValueTask<Result>(Result.Ok());

        var output = await resultTask.TapTryAsync(ThrowAction, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }
}
