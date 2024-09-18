namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureTestsTaskLeft : EnsureTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TruePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TruePredicateFunc, ErrorPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, ErrorPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, ErrorPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(ResultOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(ResultFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(ResultFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(ResultTOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(ResultTFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(ResultTFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TruePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TruePredicateFunc, ErrorPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, ErrorPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(FalsePredicateFunc, ErrorPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue>(ResultTOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue>(ResultTFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue>(ResultTFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue, TValue>(ResultTOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue, TValue>(ResultTFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue, TValue>(ResultTFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }
}
