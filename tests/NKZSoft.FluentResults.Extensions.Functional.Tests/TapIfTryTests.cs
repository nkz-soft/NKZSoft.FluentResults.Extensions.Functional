namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTryTests : TapIfTryTestsBase
{
    [Test]
    public void TapIfTryConditionFalseReturnsOriginalResultAndSkipsAction()
    {
        var result = Result.Ok();

        var output = result.TapIfTry(false, ActionEmpty);

        AssertState(output, expectedActionExecuted: false, expectedSuccess: true);
        output.Should().BeSameAs(result);
    }

    [Test]
    public void TapIfTryConditionTrueExecutesActionOnSuccess()
    {
        var output = Result.Ok().TapIfTry(true, ActionEmpty);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: true);
    }

    [Test]
    public void TapIfTryConditionTrueOnFailedSourceSkipsAction()
    {
        var result = Result.Fail(ErrorMessage);

        var output = result.TapIfTry(true, ActionEmpty);

        AssertState(output, expectedActionExecuted: false, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }

    [Test]
    public void TapIfTryPredicateFalseReturnsOriginalResultAndSkipsAction()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.TapIfTry(FalsePredicate, ActionWithValue);

        PredicateExecuted.Should().BeTrue();
        AssertState(output, expectedActionExecuted: false, expectedSuccess: true);
        output.Should().BeSameAs(result);
    }

    [Test]
    public void TapIfTryPredicateOnFailedSourceSkipsPredicateAndAction()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = result.TapIfTry(TruePredicate, ActionWithValue);

        PredicateExecuted.Should().BeFalse();
        AssertState(output, expectedActionExecuted: false, expectedSuccess: false);
    }

    [Test]
    public void TapIfTryConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok().TapIfTry(true, ThrowAction);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public void TapIfTryConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok().TapIfTry(true, ThrowAction, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public void TapIfTryTConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok(TValue.Value).TapIfTry(true, ThrowActionWithValue);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public void TapIfTryTConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok(TValue.Value).TapIfTry(true, ThrowActionWithValue, CustomErrorHandler);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: false);
        output.Errors.Should().Contain(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public void TapIfTryThrowsWhenActionIsNull()
    {
        var action = () => Result.Ok().TapIfTry(true, null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void TapIfTryTThrowsWhenActionIsNull()
    {
        var action = () => Result.Ok(TValue.Value).TapIfTry(true, (Action<TValue>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
