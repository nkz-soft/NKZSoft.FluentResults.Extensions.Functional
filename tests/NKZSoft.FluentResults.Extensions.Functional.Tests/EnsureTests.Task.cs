namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureTestsTasks : EnsureTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskTruePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskTruePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, TaskErrorPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskResultOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskResultFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskResultFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskResultTOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(EnsureTestsBase.TaskResultTFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();
        var output = await result.EnsureAsync(TaskResultTFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureTBoolPredicateIsTrue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TaskTruePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TaskFalsePredicateFunc, FailErrorMessage);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(EnsureTestsBase.TaskFalsePredicateFunc, FailErrorMessage);

        AssertSameResults(await result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureTBoolPredicateIsTrueAndSpecifiedErrorPredicate(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(EnsureTestsBase.TaskTruePredicateFunc, EnsureTestsBase.TaskErrorPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(EnsureTestsBase.TaskFalsePredicateFunc, EnsureTestsBase.TaskErrorPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsFailBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(EnsureTestsBase.TaskFalsePredicateFunc, EnsureTestsBase.TaskErrorPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureTResultPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue>(EnsureTestsBase.TaskResultTOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue>(EnsureTestsBase.TaskResultTFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsFailResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue>(EnsureTestsBase.TaskResultTFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task EnsureTResultTPredicateIsOk(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue, TValue>(EnsureTestsBase.TaskResultTOkPredicateFunc);

        AssertSameResults(await result, output, isSuccess);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue, TValue>(EnsureTestsBase.TaskResultTFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsFailResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync<TValue, TValue>(EnsureTestsBase.TaskResultTFailPredicateFunc);

        AssertSameResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkValueTaskBoolPredicateIsFalseExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TaskFalseValuePredicateFunc, FailErrorMessage);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkValueTaskBoolPredicateIsFalseAndSpecifiedErrorPredicateExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TaskFalseValuePredicateFunc, TaskErrorValuePredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkTaskResultPredicateWithoutValueIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TaskResultFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkValueTaskResultPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TaskResultValueFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }

    [Test]
    public async Task EnsureSourceResultTIsOkValueTaskResultTPredicateIsFailExpectedResultFail()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();
        var output = await result.EnsureAsync(TaskResultTValueFailPredicateFunc);

        AssertDifferentResults(await result, output, false);
    }
}
