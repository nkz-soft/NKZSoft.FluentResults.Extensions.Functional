namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTryTestsValueTaskLeft : BindTryTestsBase
{
    [Test]
    public async Task BindTryAsyncValueTaskLeftReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().BindTryAsync(OkResultFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskLeftSelectsNewTypedResult()
    {
        var output = await ValueTaskOkResultAsync().BindTryAsync(OkResultTFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskLeftConvertsExceptionToFailureWithCustomError()
    {
        var output = await ValueTaskOkResultAsync().BindTryAsync(ThrowResultFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskLeftTSelectsNewTypedResult()
    {
        var output = await ValueTaskOkResultTAsync().BindTryAsync(OkResultTFromTFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskLeftTConvertsExceptionToFailureWithDefaultError()
    {
        var output = await ValueTaskOkResultTAsync().BindTryAsync(ThrowResultFromTFunc);

        AssertDefaultFailure(output);
    }
}
