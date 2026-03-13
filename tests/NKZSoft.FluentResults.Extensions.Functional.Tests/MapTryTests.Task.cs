namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTryTestsTask : MapTryTestsBase
{
    [Test]
    public async Task MapTryAsyncTaskReturnsFailureAndDoesNotExecuteTaskFunc()
    {
        var output = await TaskFailResultAsync().MapTryAsync(TaskMapFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskSelectsNewResult()
    {
        var output = await TaskOkResultAsync().MapTryAsync(TaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncTaskConvertsTaskExceptionToFailureWithDefaultError()
    {
        var output = await TaskOkResultAsync().MapTryAsync(ThrowTaskMapFuncAsync);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskWithValueTaskFuncSelectsNewResult()
    {
        var output = await TaskOkResultAsync().MapTryAsync(ValueTaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncTaskWithValueTaskFuncConvertsExceptionToFailureWithCustomError()
    {
        var output = await TaskOkResultAsync().MapTryAsync(ThrowValueTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskTWithTaskFuncSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().MapTryAsync(TaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncTaskTWithValueTaskFuncConvertsExceptionToFailureWithCustomError()
    {
        var output = await TaskOkResultTAsync().MapTryAsync(ThrowValueTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
