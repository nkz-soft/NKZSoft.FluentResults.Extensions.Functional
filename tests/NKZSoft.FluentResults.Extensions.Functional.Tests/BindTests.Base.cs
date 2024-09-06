namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class BindTestsBase : TestBase
{
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

    protected Result<TValue> OkTFunc(TValue value)
    {
        FuncExecuted = true;
        return Result.Ok(value);
    }

    protected Task<Result<TValue>> TaskOkTFuncAsync(TValue value)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok(value));
    }

    protected ValueTask<Result<TValue>> ValueTaskOkTFuncAsync(TValue value)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok(value));
    }

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
