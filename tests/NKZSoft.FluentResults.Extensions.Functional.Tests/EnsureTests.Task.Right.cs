namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureTestsTaskRight : EnsureTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrue(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(TaskTruePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(TaskTruePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultPredicateIsOk(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(TaskResultOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(TaskResultFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(TaskResultFailPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultTPredicateIsOk(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(TaskResultTOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(EnsureTestsBase.TaskResultTFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(TaskResultTFailPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(TaskTruePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(TaskTruePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(TaskResultTOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(TaskResultTFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(TaskResultTFailPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(TaskResultTOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(TaskResultTFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(TaskResultTFailPredicateFunc);

        AssertSameResults(result, output, false);
    }
}
