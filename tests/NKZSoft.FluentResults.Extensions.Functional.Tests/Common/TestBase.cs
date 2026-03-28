namespace NKZSoft.FluentResults.Extensions.Functional.Tests.Common;

public abstract class TestBase
{
    protected const string ErrorMessage = "Error Message";
    protected bool FuncExecuted { get;  set; }

    protected static Task<Result> TaskFailResultAsync() => Task.FromResult(Result.Fail(ErrorMessage));
    protected static Task<Result> TaskOkResultAsync() => Task.FromResult(Result.Ok());

    protected static Task<Result<TValue>> TaskFailResultTAsync() => Task.FromResult(Result.Fail<TValue>(ErrorMessage));
    protected static Task<Result<TValue>> TaskOkResultTAsync() => Task.FromResult(Result.Ok(TValue.Value));


    protected static ValueTask<Result> ValueTaskFailResultAsync() => ValueTask.FromResult(Result.Fail(ErrorMessage));
    protected static ValueTask<Result> ValueTaskOkResultAsync() => ValueTask.FromResult(Result.Ok());

    protected static ValueTask<Result<TValue>> ValueTaskFailResultTAsync() => ValueTask.FromResult(Result.Fail<TValue>(ErrorMessage));
    protected static ValueTask<Result<TValue>> ValueTaskOkResultTAsync() => ValueTask.FromResult(Result.Ok(TValue.Value));

    public static void AssertResultParity(Result left, Result right)
    {
        left.IsSuccess.Should().Be(right.IsSuccess);
        left.IsFailed.Should().Be(right.IsFailed);
        left.Errors.Select(static e => e.Message).Should().Equal(right.Errors.Select(static e => e.Message));
    }

    public static void AssertResultParity<T>(Result<IEnumerable<T>> left, Result<IEnumerable<T>> right)
    {
        left.IsSuccess.Should().Be(right.IsSuccess);
        left.IsFailed.Should().Be(right.IsFailed);
        left.Errors.Select(static e => e.Message).Should().Equal(right.Errors.Select(static e => e.Message));
        if (left.IsSuccess && right.IsSuccess)
        {
            left.Value.Should().Equal(right.Value);
        }
    }

    protected class TValue
    {
        public static readonly TValue Value = new();
    }
}
