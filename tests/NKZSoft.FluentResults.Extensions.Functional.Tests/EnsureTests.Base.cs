namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class EnsureTestsBase : TestBase
{
    protected const string FailErrorMessage = "Fail Error Message";

    protected static bool TruePredicateFunc() => true;

    protected static Task<bool> TaskTruePredicateFunc() => Task.FromResult(true);

    protected static ValueTask<bool> ValueTaskTruePredicateFunc() => ValueTask.FromResult(true);

    protected static bool FalsePredicateFunc() => false;

    protected static Task<bool> TaskFalsePredicateFunc() => Task.FromResult(false);

    protected static ValueTask<bool> ValueTaskFalsePredicateFunc() => ValueTask.FromResult(false);
    protected static IList<IError> ErrorPredicateFunc()
        => new List<IError> { new Error(FailErrorMessage) };

    protected static async Task<IList<IError>> TaskErrorPredicateFunc()
        => await Task.FromResult(new List<IError> { new Error(FailErrorMessage) });

    protected static async ValueTask<IList<IError>> ValueTaskErrorPredicateFunc()
        => await ValueTask.FromResult(new List<IError> { new Error(FailErrorMessage) });

    protected static Result ResultOkPredicateFunc() => Result.Ok();

    protected static async Task<Result> TaskResultOkPredicateFunc()
        => await Task.FromResult(Result.Ok());

    protected static async ValueTask<Result> ValueTaskResultOkPredicateFunc()
        => await ValueTask.FromResult(Result.Ok());

    protected static Result ResultFailPredicateFunc() => Result.Fail(ErrorMessage);

    protected static async Task<Result> TaskResultFailPredicateFunc()
        => await Task.FromResult(Result.Fail(ErrorMessage));

    protected static async ValueTask<Result> ValueTaskResultFailPredicateFunc()
        => await ValueTask.FromResult(Result.Fail(ErrorMessage));

    protected static Result<TValue> ResultTOkPredicateFunc() => Result.Ok(TValue.Value);

    protected static async Task<Result<TValue>> TaskResultTOkPredicateFunc()
        => await Task.FromResult(Result.Ok(TValue.Value));

    protected static async ValueTask<Result<TValue>> ValueTaskResultTOkPredicateFunc()
        => await ValueTask.FromResult(Result.Ok(TValue.Value));

    protected static Result<TValue> ResultTFailPredicateFunc()
        => Result.Fail<TValue>(FailErrorMessage);

    protected static async Task<Result<TValue>> TaskResultTFailPredicateFunc()
        => await Task.FromResult(Result.Fail<TValue>(FailErrorMessage));

    protected static async ValueTask<Result<TValue>> ValueTaskResultTFailPredicateFunc()
        => await ValueTask.FromResult(Result.Fail<TValue>(FailErrorMessage));

    protected static void AssertSuccess(Result output, bool isSuccess)
        => output.IsSuccess.Should().Be(isSuccess);

    protected static void AssertSuccess(Result<TValue> output, bool isSuccess)
        => output.IsSuccess.Should().Be(isSuccess);

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
