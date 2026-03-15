namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class BindIfTestsBase : TestBase
{
    protected static readonly TValue BoundValue = new();
    protected bool PredicateExecuted { get; private set; }

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

    protected Result OkFunc()
    {
        FuncExecuted = true;
        return Result.Ok();
    }

    protected Task<Result> TaskOkFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok());
    }

    protected ValueTask<Result> ValueTaskOkFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok());
    }

    protected Result<TValue> BindToBoundValue(TValue value)
    {
        FuncExecuted = true;
        return Result.Ok(BoundValue);
    }

    protected Task<Result<TValue>> TaskBindToBoundValueAsync(TValue value)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok(BoundValue));
    }

    protected ValueTask<Result<TValue>> ValueTaskBindToBoundValueAsync(TValue value)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok(BoundValue));
    }

    protected Result<TValue> FailBind(TValue value)
    {
        FuncExecuted = true;
        return Result.Fail<TValue>(ErrorMessage);
    }

    protected Task<Result<TValue>> TaskFailBindAsync(TValue value)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Fail<TValue>(ErrorMessage));
    }

    protected ValueTask<Result<TValue>> ValueTaskFailBindAsync(TValue value)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Fail<TValue>(ErrorMessage));
    }
}
