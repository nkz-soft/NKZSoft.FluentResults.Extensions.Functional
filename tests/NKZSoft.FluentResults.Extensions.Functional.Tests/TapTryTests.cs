namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapTryTests : TapTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void TapTryExecutesActionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = result.TapTry(ActionEmpty);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void TapTryTExecutesActionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = result.TapTry(ActionEmpty);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void TapTryTExecutesActionWithValueOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = result.TapTry(ActionWithValue);

        AssertState(output, expectedActionExecuted: isSuccess, expectedSuccess: isSuccess);
    }

    [Test]
    public void TapTryConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok().TapTry(ThrowAction);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public void TapTryConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok().TapTry(ThrowAction, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public void TapTryTConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok(TValue.Value).TapTry(ThrowActionWithValue);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public void TapTryTConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok(TValue.Value).TapTry(ThrowActionWithValue, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public void TapTryThrowsWhenActionIsNull()
    {
        var action = () => Result.Ok().TapTry(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void TapTryTThrowsWhenActionIsNull()
    {
        var action = () => Result.Ok(TValue.Value).TapTry((Action<TValue>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
