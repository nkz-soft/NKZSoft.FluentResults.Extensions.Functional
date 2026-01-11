namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class CheckTestsBase : TestBase
{
    protected Result OkCheck()
    {
        FuncExecuted = true;
        return Result.Ok();
    }

    protected Result FailCheck()
    {
        FuncExecuted = true;
        return Result.Fail(ErrorMessage);
    }

    protected Result OkCheck(TValue value)
    {
        FuncExecuted = true;
        return Result.Ok();
    }

    protected Result FailCheck(TValue value)
    {
        FuncExecuted = true;
        return Result.Fail(ErrorMessage);
    }

    protected Task<Result> TaskOkCheckAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok());
    }

    protected Task<Result> TaskFailCheckAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Fail(ErrorMessage));
    }

    protected Task<Result> TaskOkCheckAsync(TValue value)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok());
    }

    protected Task<Result> TaskFailCheckAsync(TValue value)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Fail(ErrorMessage));
    }

    protected ValueTask<Result> ValueTaskOkCheckAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok());
    }

    protected ValueTask<Result> ValueTaskFailCheckAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Fail(ErrorMessage));
    }

    protected ValueTask<Result> ValueTaskOkCheckAsync(TValue value)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok());
    }

    protected ValueTask<Result> ValueTaskFailCheckAsync(TValue value)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Fail(ErrorMessage));
    }

    protected async ValueTask<Result> ValueTaskOkCheckYieldAsync()
    {
        FuncExecuted = true;
        await Task.Yield();
        return Result.Ok();
    }

    protected async ValueTask<Result> ValueTaskOkCheckYieldAsync(TValue value)
    {
        FuncExecuted = true;
        await Task.Yield();
        return Result.Ok();
    }

    protected static void AssertSameInstance(Result expected, Result output)
        => output.Should().BeSameAs(expected);

    protected static void AssertSameInstance<TValue>(Result<TValue> expected, Result<TValue> output)
        => output.Should().BeSameAs(expected);

    protected static void AssertFailedWithErrors(Result output, Result checkResult)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().BeEquivalentTo(checkResult.Errors);
    }

    protected static void AssertFailedWithErrors<TValue>(Result<TValue> output, Result checkResult)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().BeEquivalentTo(checkResult.Errors);
    }
}
