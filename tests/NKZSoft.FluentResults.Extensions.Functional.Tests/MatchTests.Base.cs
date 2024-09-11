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

    protected void Failure(IList<IError> errors) => ActionOnFailureExecuted = true;

    protected TValue ValueFailure(IList<IError> errors)
    {
        Failure(errors);
        return TValue.Value;
    }

    protected Task FailureAsync(IList<IError> arg)
    {
        Failure(arg);
        return Task.CompletedTask;
    }

    protected Task SuccessEmptyAsync()
    {
        SuccessEmpty();
        return Task.CompletedTask;
    }

    protected Task<TValue> ValueFailureAsync(IList<IError> arg)
    {
        Failure(arg);
        return Task.FromResult(TValue.Value);
    }

    protected Task<TValue> ValueSuccessAsync()
    {
        SuccessEmpty();
        return Task.FromResult(TValue.Value);
    }

    protected Task<TValue> ValueSuccessTAsync(TValue value)
    {
        SuccessEmpty();
        return Task.FromResult(TValue.Value);
    }

    protected  Task<TValue> ValueFailureTAsync(IList<IError> arg)
    {
        Failure(arg);
        return Task.FromResult(TValue.Value);
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
