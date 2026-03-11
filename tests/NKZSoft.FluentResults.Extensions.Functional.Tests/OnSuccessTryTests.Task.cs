namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTestsTask : OnSuccessTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncExecutesTaskFunctionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();

        var output = await resultTask.OnSuccessTryAsync(TaskActionEmptyAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncTExecutesTaskFunctionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();

        var output = await resultTask.OnSuccessTryAsync(TaskActionWithValueAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    public async Task OnSuccessTryAsyncConvertsTaskExceptionToFailureWithDefaultError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .OnSuccessTryAsync(ThrowTaskActionAsync);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task OnSuccessTryAsyncConvertsTaskExceptionToFailureWithCustomError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .OnSuccessTryAsync(ThrowTaskActionAsync, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task OnSuccessTryAsyncThrowsWhenFunctionIsNull()
    {
        var action = async () => await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .OnSuccessTryAsync((Func<Task>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
