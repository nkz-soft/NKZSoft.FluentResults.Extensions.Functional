namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureTestsValueTaskRight : EnsureTestsBase
{
        [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrue(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultPredicateIsOk(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultFailPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultTPredicateIsOk(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultTOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultTFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultTFailPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(ValueTaskResultTOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(ValueTaskResultTFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(ValueTaskResultTFailPredicateFunc);

        AssertSameResults(result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(ValueTaskResultTOkPredicateFunc);

        AssertSameResults(result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(ValueTaskResultTFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(ValueTaskResultTFailPredicateFunc);

        AssertSameResults(result, output, false);
    }
}
