namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class MapIfTestsBase : TestBase
{
    protected static readonly TValue MappedValue = new();

    protected bool PredicateExecuted { get; private set; }

    protected TValue MapFunc(TValue value)
    {
        FuncExecuted = true;
        return MappedValue;
    }

    protected Task<TValue> TaskMapFuncAsync(TValue value)
    {
        FuncExecuted = true;
        return Task.FromResult(MappedValue);
    }

    protected ValueTask<TValue> ValueTaskMapFuncAsync(TValue value)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(MappedValue);
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

    protected void AssertMapped(Result<TValue> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(MappedValue);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertSkipped(Result<TValue> source, Result<TValue> output, bool predicateExecuted)
    {
        PredicateExecuted.Should().Be(predicateExecuted);
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(source);
    }

    protected void AssertFailurePreserved(Result<TValue> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == ErrorMessage);
        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
    }
}
