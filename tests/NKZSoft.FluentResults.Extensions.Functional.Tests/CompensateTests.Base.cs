namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class CompensateTestsBase : TestBase
{
    protected IReadOnlyCollection<IError>? ReceivedErrors { get; private set; }

    protected Result OkCompensate()
    {
        FuncExecuted = true;
        return Result.Ok();
    }

    protected Result<TValue> OkCompensateT()
    {
        FuncExecuted = true;
        return Result.Ok(TValue.Value);
    }

    protected Result FailCompensate()
    {
        FuncExecuted = true;
        return Result.Fail(ErrorMessage);
    }

    protected Result<TValue> FailCompensateT()
    {
        FuncExecuted = true;
        return Result.Fail<TValue>(ErrorMessage);
    }

    protected Result OkCompensate(IReadOnlyCollection<IError> errors)
    {
        FuncExecuted = true;
        ReceivedErrors = errors;
        return Result.Ok();
    }

    protected Result<TValue> OkCompensateT(IReadOnlyCollection<IError> errors)
    {
        FuncExecuted = true;
        ReceivedErrors = errors;
        return Result.Ok(TValue.Value);
    }

    protected Task<Result> TaskOkCompensateAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok());
    }

    protected Task<Result<TValue>> TaskOkCompensateTAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok(TValue.Value));
    }

    protected Task<Result> TaskOkCompensateAsync(IReadOnlyCollection<IError> errors)
    {
        FuncExecuted = true;
        ReceivedErrors = errors;
        return Task.FromResult(Result.Ok());
    }

    protected Task<Result<TValue>> TaskOkCompensateTAsync(IReadOnlyCollection<IError> errors)
    {
        FuncExecuted = true;
        ReceivedErrors = errors;
        return Task.FromResult(Result.Ok(TValue.Value));
    }

    protected ValueTask<Result> ValueTaskOkCompensateAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok());
    }

    protected ValueTask<Result<TValue>> ValueTaskOkCompensateTAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok(TValue.Value));
    }

    protected ValueTask<Result> ValueTaskOkCompensateAsync(IReadOnlyCollection<IError> errors)
    {
        FuncExecuted = true;
        ReceivedErrors = errors;
        return ValueTask.FromResult(Result.Ok());
    }

    protected ValueTask<Result<TValue>> ValueTaskOkCompensateTAsync(IReadOnlyCollection<IError> errors)
    {
        FuncExecuted = true;
        ReceivedErrors = errors;
        return ValueTask.FromResult(Result.Ok(TValue.Value));
    }
}
