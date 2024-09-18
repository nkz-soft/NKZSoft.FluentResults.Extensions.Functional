namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class EnsureTestsValueTask : EnsureTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, FailErrorMessage);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertSuccess(output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSuccess(output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultOkPredicateFunc);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultFailPredicateFunc);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultFailPredicateFunc);

        AssertSuccess(output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultTOkPredicateFunc);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultTFailPredicateFunc);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage);
        var output = await result.EnsureAsync(ValueTaskResultTFailPredicateFunc);

        AssertSuccess(output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, FailErrorMessage);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, FailErrorMessage);

        AssertSuccess(output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskTruePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync(ValueTaskFalsePredicateFunc, ValueTaskErrorPredicateFunc);

        AssertSuccess(output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(ValueTaskResultTOkPredicateFunc);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(ValueTaskResultTFailPredicateFunc);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue>(ValueTaskResultTFailPredicateFunc);

        AssertSuccess(output, false);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task EnsureTResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(ValueTaskResultTOkPredicateFunc);

        AssertSuccess(output, isSuccess);
    }

    [Fact]
    public async Task EnsureSourceResultTIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(ValueTaskResultTFailPredicateFunc);

        AssertSuccess(output, false);
    }

    [Fact]
    public async Task EnsureSourceResultTIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value);
        var output = await result.EnsureAsync<TValue, TValue>(ValueTaskResultTFailPredicateFunc);

        AssertSuccess(output, false);
    }
}
