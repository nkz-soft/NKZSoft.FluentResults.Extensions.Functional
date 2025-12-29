namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class MatchTestsBase : TestBase
{
    private bool ActionOnSuccessExecuted { get;  set; }
    private bool ActionOnFailureExecuted { get;  set; }

    protected void SuccessEmpty() => ActionOnSuccessExecuted = true;

    protected void SuccessT(TValue obj) => SuccessEmpty();

    protected TValue ValueSuccess()
    {
        SuccessEmpty();
        return TValue.Value;
    }

    protected TValue ValueSuccessT(TValue obj) => ValueSuccess();

    protected void Failure(IReadOnlyList<IError> errors) => ActionOnFailureExecuted = true;

    protected TValue ValueFailure(IReadOnlyList<IError> errors)
    {
        Failure(errors);
        return TValue.Value;
    }

    protected Task TaskFailure(IReadOnlyList<IError> arg)
    {
        Failure(arg);
        return Task.CompletedTask;
    }

    protected ValueTask ValueTaskFailure(IReadOnlyList<IError> arg)
    {
        Failure(arg);
        return ValueTask.CompletedTask;
    }

    protected Task TaskSuccessEmpty()
    {
        SuccessEmpty();
        return Task.CompletedTask;
    }

    protected ValueTask ValueTaskSuccessEmpty()
    {
        SuccessEmpty();
        return ValueTask.CompletedTask;
    }

    protected Task<TValue> TaskValueFailure(IReadOnlyList<IError> arg)
    {
        Failure(arg);
        return Task.FromResult(TValue.Value);
    }

    protected ValueTask<TValue> ValueTaskValueFailure(IReadOnlyList<IError> arg)
    {
        Failure(arg);
        return ValueTask.FromResult(TValue.Value);
    }

    protected Task<TValue> TaskValueSuccess()
    {
        SuccessEmpty();
        return Task.FromResult(TValue.Value);
    }

    protected ValueTask<TValue> ValueTaskValueSuccess()
    {
        SuccessEmpty();
        return ValueTask.FromResult(TValue.Value);
    }

    protected Task<TValue> TaskValueSuccessT(TValue value)
    {
        SuccessEmpty();
        return Task.FromResult(TValue.Value);
    }

    protected ValueTask<TValue> ValueTaskValueSuccessT(TValue value)
    {
        SuccessEmpty();
        return ValueTask.FromResult(TValue.Value);
    }

    protected  Task<TValue> TaskValueFailureT(IReadOnlyList<IError> arg)
    {
        Failure(arg);
        return Task.FromResult(TValue.Value);
    }

    protected  ValueTask<TValue> ValueTaskValueFailureT(IReadOnlyList<IError> arg)
    {
        Failure(arg);
        return ValueTask.FromResult(TValue.Value);
    }

    protected void AssertSuccess(Result<TValue> output, bool isSuccess)
    {
        AssertSuccess(isSuccess);
        output.IsSuccess.Should().Be(isSuccess);
    }

    protected void AssertSuccess(bool isSuccess)
    {
        ActionOnSuccessExecuted.Should().Be(isSuccess);
        ActionOnFailureExecuted.Should().Be(!isSuccess);
    }
}
