namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class BindTryTestsBase : TestBase
{
    protected const string TryExceptionMessage = "BindTry Exception Message";
    protected const string CustomErrorMessage = "Custom BindTry Error Message";

    protected class TValueMapped
    {
        public static readonly TValueMapped Value = new();
    }

    protected Result OkResultFunc()
    {
        FuncExecuted = true;
        return Result.Ok();
    }

    protected Result FailResultFunc()
    {
        FuncExecuted = true;
        return Result.Fail(ErrorMessage);
    }

    protected Result ThrowResultFunc()
    {
        FuncExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected Result<TValueMapped> OkResultTFunc()
    {
        FuncExecuted = true;
        return Result.Ok(TValueMapped.Value);
    }

    protected Result<TValueMapped> FailResultTFunc()
    {
        FuncExecuted = true;
        return Result.Fail<TValueMapped>(ErrorMessage);
    }

    protected Result<TValueMapped> ThrowResultTFunc()
    {
        FuncExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected Result OkResultFromTFunc(TValue _)
    {
        FuncExecuted = true;
        return Result.Ok();
    }

    protected Result FailResultFromTFunc(TValue _)
    {
        FuncExecuted = true;
        return Result.Fail(ErrorMessage);
    }

    protected Result ThrowResultFromTFunc(TValue _)
    {
        FuncExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected Result<TValueMapped> OkResultTFromTFunc(TValue _)
    {
        FuncExecuted = true;
        return Result.Ok(TValueMapped.Value);
    }

    protected Result<TValueMapped> FailResultTFromTFunc(TValue _)
    {
        FuncExecuted = true;
        return Result.Fail<TValueMapped>(ErrorMessage);
    }

    protected Result<TValueMapped> ThrowResultTFromTFunc(TValue _)
    {
        FuncExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected Task<Result> TaskOkResultFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok());
    }

    protected Task<Result> ThrowTaskResultFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromException<Result>(new InvalidOperationException(TryExceptionMessage));
    }

    protected Task<Result<TValueMapped>> TaskOkResultTFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok(TValueMapped.Value));
    }

    protected Task<Result<TValueMapped>> ThrowTaskResultTFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromException<Result<TValueMapped>>(new InvalidOperationException(TryExceptionMessage));
    }

    protected Task<Result> TaskOkResultFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok());
    }

    protected Task<Result> ThrowTaskResultFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return Task.FromException<Result>(new InvalidOperationException(TryExceptionMessage));
    }

    protected Task<Result<TValueMapped>> TaskOkResultTFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok(TValueMapped.Value));
    }

    protected Task<Result<TValueMapped>> ThrowTaskResultTFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return Task.FromException<Result<TValueMapped>>(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask<Result> ValueTaskOkResultFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok());
    }

    protected ValueTask<Result> ThrowValueTaskResultFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromException<Result>(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask<Result<TValueMapped>> ValueTaskOkResultTFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok(TValueMapped.Value));
    }

    protected ValueTask<Result<TValueMapped>> ThrowValueTaskResultTFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromException<Result<TValueMapped>>(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask<Result> ValueTaskOkResultFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok());
    }

    protected ValueTask<Result> ThrowValueTaskResultFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromException<Result>(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask<Result<TValueMapped>> ValueTaskOkResultTFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok(TValueMapped.Value));
    }

    protected ValueTask<Result<TValueMapped>> ThrowValueTaskResultTFromTFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromException<Result<TValueMapped>>(new InvalidOperationException(TryExceptionMessage));
    }

    protected static string CustomErrorHandler(Exception _) => CustomErrorMessage;

    protected void AssertSuccess(Result output)
    {
        output.IsSuccess.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertSuccess(Result<TValueMapped> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValueMapped.Value);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertSourceFailure(Result output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == ErrorMessage);
        FuncExecuted.Should().BeFalse();
    }

    protected void AssertSourceFailure(Result<TValueMapped> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == ErrorMessage);
        FuncExecuted.Should().BeFalse();
    }

    protected void AssertDefaultFailure(Result output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertDefaultFailure(Result<TValueMapped> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertCustomFailure(Result output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertCustomFailure(Result<TValueMapped> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
        FuncExecuted.Should().BeTrue();
    }
}
