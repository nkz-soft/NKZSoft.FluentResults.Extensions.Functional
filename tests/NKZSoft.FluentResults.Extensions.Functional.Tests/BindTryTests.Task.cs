namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTryTestsTask : BindTryTestsBase
{
    [Test]
    public async Task BindTryAsyncTaskReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().BindTryAsync(TaskOkResultFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindTryAsyncTaskSelectsNewTypedResult()
    {
        var output = await TaskOkResultAsync().BindTryAsync(TaskOkResultTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncTaskConvertsExceptionToFailureWithCustomError()
    {
        var output = await TaskOkResultAsync().BindTryAsync(ThrowTaskResultFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task BindTryAsyncTaskTSelectsNewTypedResult()
    {
        var output = await TaskOkResultTAsync().BindTryAsync(TaskOkResultTFromTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncTaskTConvertsExceptionToFailureWithDefaultError()
    {
        var output = await TaskOkResultTAsync().BindTryAsync(ThrowTaskResultFromTFuncAsync);

        AssertDefaultFailure(output);
    }
}
