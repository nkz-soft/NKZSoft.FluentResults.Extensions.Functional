namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public abstract class CheckIfTestsBase : CheckTestsBase
{
    protected bool PredicateExecuted { get; private set; }

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
}
