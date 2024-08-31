namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class BindTestsBase : TestBase
{
    protected bool FuncExecuted { get;  private set; }

    protected Result Success()
    {
        FuncExecuted = true;
        return Result.Ok();
    }

    protected Result<T> SuccessT<T>(T value)
    {
        FuncExecuted = true;
        return Result.Ok(value);
    }

    protected Task<Result> TaskSuccess() => Task.FromResult(Success());

    protected ValueTask<Result> ValueTaskSuccess() => ValueTask.FromResult(Success());

    protected static Task<Result> TaskFailure() => Task.FromResult(Result.Fail(ErrorMessage));

    protected static ValueTask<Result> ValueTaskFailure() => ValueTask.FromResult(Result.Fail(ErrorMessage));

    protected static Task<Result<TValue>> TaskFailureT<TValue>() => Task.FromResult(Result.Fail<TValue>(ErrorMessage));

    protected static ValueTask<Result<TValue>> ValueTaskFailureT<TValue>() => ValueTask.FromResult(Result.Fail<TValue>(ErrorMessage));

    protected Task<Result<TValue>> TaskSuccessT<TValue>(TValue value) => Task.FromResult(SuccessT(value));

    protected ValueTask<Result<TValue>> ValueTaskSuccessT<TValue>(TValue value) => ValueTask.FromResult(SuccessT(value));

    protected void AssertFailure(Result output)
    {
        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Errors.Should().Contain(e => e.Message == ErrorMessage);
    }

    protected void AssertFailure<T>(Result<T> output)
    {
        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Errors.Should().Contain(e => e.Message == ErrorMessage);
    }

    protected void AssertSuccess(Result output)
    {
        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    protected void AssertSuccess<T>(Result<T> output)
    {
        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }
}
