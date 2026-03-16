namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class TapIfTestsBase : TestBase
{
    protected bool ActionExecuted { get; private set; }
    protected bool PredicateExecuted { get; private set; }

    protected void ActionEmpty() => ActionExecuted = true;

    protected void ActionT(TValue value) => ActionExecuted = true;

    protected Task TaskActionEmptyAsync()
    {
        ActionExecuted = true;
        return Task.CompletedTask;
    }

    protected Task TaskActionTAsync(TValue value)
    {
        ActionExecuted = true;
        return Task.CompletedTask;
    }

    protected ValueTask ValueTaskActionEmptyAsync()
    {
        ActionExecuted = true;
        return ValueTask.CompletedTask;
    }

    protected ValueTask ValueTaskActionTAsync(TValue value)
    {
        ActionExecuted = true;
        return ValueTask.CompletedTask;
    }

    protected bool TruePredicate()
    {
        PredicateExecuted = true;
        return true;
    }

    protected bool FalsePredicate()
    {
        PredicateExecuted = true;
        return false;
    }

    protected bool TruePredicate(TValue value)
    {
        PredicateExecuted = true;
        return true;
    }

    protected bool FalsePredicate(TValue value)
    {
        PredicateExecuted = true;
        return false;
    }

    protected void AssertSkipped(Result expected, Result output, bool predicateExecuted)
    {
        PredicateExecuted.Should().Be(predicateExecuted);
        ActionExecuted.Should().BeFalse();
        output.Should().BeSameAs(expected);
    }

    protected void AssertSkipped(Result<TValue> expected, Result<TValue> output, bool predicateExecuted)
    {
        PredicateExecuted.Should().Be(predicateExecuted);
        ActionExecuted.Should().BeFalse();
        output.Should().BeSameAs(expected);
    }

    protected void AssertExecuted(Result output, bool shouldExecute, bool isSuccess)
    {
        ActionExecuted.Should().Be(shouldExecute);
        output.IsSuccess.Should().Be(isSuccess);
    }

    protected void AssertExecuted(Result<TValue> output, bool shouldExecute, bool isSuccess)
    {
        ActionExecuted.Should().Be(shouldExecute);
        output.IsSuccess.Should().Be(isSuccess);
    }
}
