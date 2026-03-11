namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureTests : EnsureTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureBoolPredicateIsTrue(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = result.Ensure(() => true, FailErrorMessage);

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);

        var output = result.Ensure(() => false, FailErrorMessage);

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);

        var output = result.Ensure(() => false, FailErrorMessage);

        AssertSameResults(result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = result.Ensure(() => true,
            () => new List<IError> { new Error(FailErrorMessage) });

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);

        var output = result.Ensure(() => false,
            () => new List<IError> { new Error(FailErrorMessage) });

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);

        var output = result.Ensure(() => false,
            () => new List<IError> { new Error(FailErrorMessage) });

        AssertSameResults(result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureResultPredicateIsOk(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = result.Ensure(Result.Ok);

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);

        var output = result.Ensure(() => Result.Fail(FailErrorMessage));

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);

        var output = result.Ensure(() => Result.Fail(FailErrorMessage));

        AssertSameResults(result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureResultTPredicateIsOk(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = result.Ensure(() => Result.Ok(TValue.Value));

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(true, ErrorMessage);

        var output = result.Ensure(() => Result.Fail<TValue>(FailErrorMessage));

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = Result.OkIf(false, ErrorMessage);

        var output = result.Ensure(() => Result.Fail<TValue>(FailErrorMessage));

        AssertSameResults(result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureTBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = result.Ensure(() => true, FailErrorMessage);

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultTIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure(() => false, FailErrorMessage);

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);

        var output = result.Ensure(() => false, FailErrorMessage);

        AssertSameResults(result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureTBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = result.Ensure(() => true,
            () => new List<IError> { new Error(FailErrorMessage) });

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultTIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure(() => false,
            () => new List<IError> { new Error(FailErrorMessage) });

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);

        var output = result.Ensure(() => false,
            () => new List<IError> { new Error(FailErrorMessage) });

        AssertSameResults(result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureTResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = result.Ensure<TValue>(() => Result.Ok(TValue.Value));

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultTIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure<TValue>(() => Result.Fail<TValue>(FailErrorMessage));

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);

        var output = result.Ensure<TValue>(() => Result.Fail<TValue>(FailErrorMessage));

        AssertSameResults(result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void EnsureTResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = result.Ensure<TValue, TValue>(() => Result.Ok(TValue.Value));

        AssertSameResults(result, output, isSuccess);
    }

    [Test]
    public void EnsureSourceResultTIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure<TValue, TValue>(() => Result.Fail<TValue>(FailErrorMessage));

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(false, ErrorMessage, TValue.Value);

        var output = result.Ensure<TValue, TValue>(() => Result.Fail<TValue>(FailErrorMessage));

        AssertSameResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsOkValueBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure(FalseValuePredicateFunc, FailErrorMessage);

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsOkValueBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure(FalseValuePredicateFunc, ErrorValuePredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsOkResultPredicateWithoutValueIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure(() => Result.Fail(FailErrorMessage));

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsOkValueResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure(ResultValueFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }

    [Test]
    public void EnsureSourceResultTIsOkValueResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIf(true, ErrorMessage, TValue.Value);

        var output = result.Ensure(ResultTValueFailPredicateFunc);

        AssertDifferentResults(result, output, false);
    }
}
