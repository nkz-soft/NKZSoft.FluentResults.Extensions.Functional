namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTests : TapIfTestsBase
{
    [Test]
    public void TapIfConditionFalseReturnsOriginalResultAndSkipsAction()
    {
        var result = Result.Ok();

        var output = result.TapIf(false, ActionEmpty);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public void TapIfConditionTrueExecutesActionOnSuccess()
    {
        var output = Result.Ok().TapIf(true, ActionEmpty);

        AssertExecuted(output, shouldExecute: true, isSuccess: true);
    }

    [Test]
    public void TapIfConditionTrueOnFailedSourceSkipsAction()
    {
        var result = Result.Fail(ErrorMessage);

        var output = result.TapIf(true, ActionEmpty);

        AssertExecuted(output, shouldExecute: false, isSuccess: false);
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }

    [Test]
    public void TapIfPredicateOnFailedSourceSkipsPredicateAndAction()
    {
        var result = Result.Fail(ErrorMessage);

        var output = result.TapIf(TruePredicate, ActionEmpty);

        PredicateExecuted.Should().BeFalse();
        ActionExecuted.Should().BeFalse();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }

    [Test]
    public void TapIfConditionTrueExecutesActionTOnSuccess()
    {
        var output = Result.Ok(TValue.Value).TapIf(true, ActionT);

        AssertExecuted(output, shouldExecute: true, isSuccess: true);
    }

    [Test]
    public void TapIfPredicateFalseReturnsOriginalResultAndSkipsAction()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.TapIf(FalsePredicate, ActionEmpty);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public void TapIfPredicateTrueExecutesActionTOnSuccess()
    {
        var output = Result.Ok(TValue.Value).TapIf(TruePredicate, ActionT);

        PredicateExecuted.Should().BeTrue();
        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void TapIfPredicateOnFailedResultTSkipsPredicateAndAction()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = result.TapIf(TruePredicate, ActionT);

        PredicateExecuted.Should().BeFalse();
        ActionExecuted.Should().BeFalse();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
