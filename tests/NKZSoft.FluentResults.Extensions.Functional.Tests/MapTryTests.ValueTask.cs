namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTryTestsValueTask : MapTryTestsBase
{
    [Test]
    public async Task MapTryAsyncValueTaskReturnsFailureAndDoesNotExecuteValueTaskFunc()
    {
        var output = await ValueTaskFailResultAsync().MapTryAsync(ValueTaskMapFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskSelectsNewResult()
    {
        var output = await ValueTaskOkResultAsync().MapTryAsync(ValueTaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskConvertsValueTaskExceptionToFailureWithDefaultError()
    {
        var output = await ValueTaskOkResultAsync().MapTryAsync(ThrowValueTaskMapFuncAsync);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskWithTaskFuncSelectsNewResult()
    {
        var output = await ValueTaskOkResultAsync().MapTryAsync(TaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskWithTaskFuncConvertsExceptionToFailureWithCustomError()
    {
        var output = await ValueTaskOkResultAsync().MapTryAsync(ThrowTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskTWithValueTaskFuncSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().MapTryAsync(ValueTaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskTWithTaskFuncConvertsExceptionToFailureWithCustomError()
    {
        var output = await ValueTaskOkResultTAsync().MapTryAsync(ThrowTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
