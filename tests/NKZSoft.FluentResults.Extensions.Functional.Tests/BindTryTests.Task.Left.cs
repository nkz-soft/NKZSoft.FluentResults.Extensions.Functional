namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTryTestsTaskLeft : BindTryTestsBase
{
    [Test]
    public async Task BindTryAsyncTaskLeftReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().BindTryAsync(OkResultFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindTryAsyncTaskLeftSelectsNewTypedResult()
    {
        var output = await TaskOkResultAsync().BindTryAsync(OkResultTFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncTaskLeftConvertsExceptionToFailureWithCustomError()
    {
        var output = await TaskOkResultAsync().BindTryAsync(ThrowResultFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task BindTryAsyncTaskLeftTSelectsNewTypedResult()
    {
        var output = await TaskOkResultTAsync().BindTryAsync(OkResultTFromTFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncTaskLeftTConvertsExceptionToFailureWithDefaultError()
    {
        var output = await TaskOkResultTAsync().BindTryAsync(ThrowResultFromTFunc);

        AssertDefaultFailure(output);
    }
}
