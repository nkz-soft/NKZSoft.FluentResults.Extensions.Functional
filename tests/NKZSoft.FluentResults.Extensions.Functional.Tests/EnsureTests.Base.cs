namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class EnsureTestsBase : TestBase
{
    protected const string FailErrorMessage = "Fail Error Message";

    protected static Task<bool> TaskTruePredicateFunc() => Task.FromResult(true);

    protected static ValueTask<bool> ValueTaskTruePredicateFunc() => ValueTask.FromResult(true);

    protected static Task<bool> TaskFalsePredicateFunc() => Task.FromResult(false);

    protected static ValueTask<bool> ValueTaskFalsePredicateFunc() => ValueTask.FromResult(false);

    protected static async Task<IList<IError>> TaskErrorPredicateFunc()
        => await Task.FromResult(new List<IError> { new Error(FailErrorMessage) });

    protected static async ValueTask<IList<IError>> ValueTaskErrorPredicateFunc()
        => await ValueTask.FromResult(new List<IError> { new Error(FailErrorMessage) });

    protected static async Task<Result> TaskResultOkPredicateFunc()
        => await Task.FromResult(Result.Ok());

    protected static async ValueTask<Result> ValueTaskResultOkPredicateFunc()
        => await ValueTask.FromResult(Result.Ok());

    protected static async Task<Result> TaskResultFailPredicateFunc()
        => await Task.FromResult(Result.Fail(ErrorMessage));

    protected static async ValueTask<Result> ValueTaskResultFailPredicateFunc()
        => await ValueTask.FromResult(Result.Fail(ErrorMessage));

    protected static async Task<Result<TValue>> TaskResultTOkPredicateFunc()
        => await Task.FromResult(Result.Ok(TValue.Value));

    protected static async ValueTask<Result<TValue>> ValueTaskResultTOkPredicateFunc()
        => await ValueTask.FromResult(Result.Ok(TValue.Value));

    protected static async Task<Result<TValue>> TaskResultTFailPredicateFunc()
        => await Task.FromResult(Result.Fail<TValue>(FailErrorMessage));

    protected static async ValueTask<Result<TValue>> ValueTaskResultTFailPredicateFunc()
        => await ValueTask.FromResult(Result.Fail<TValue>(FailErrorMessage));

    protected void AssertSuccess(Result output, bool isSuccess)
    {
        output.IsSuccess.Should().Be(isSuccess);
    }
    protected void AssertSuccess(Result<TValue> output, bool isSuccess)
    {
        output.IsSuccess.Should().Be(isSuccess);
    }

    protected static void AssertSameResults(Result result, Result output, bool isOutputSuccess)
    {
        result.Should().Be(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }

    protected static void AssertSameResults(Result<TValue> result, Result<TValue> output, bool isOutputSuccess)
    {
        result.Should().Be(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }

    protected static void AssertDifferentResults(Result result, Result output, bool isOutputSuccess)
    {
        result.Should().NotBe(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }

    protected static void AssertDifferentResults(Result<TValue> result, Result<TValue> output, bool isOutputSuccess)
    {
        result.Should().NotBe(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }
}
