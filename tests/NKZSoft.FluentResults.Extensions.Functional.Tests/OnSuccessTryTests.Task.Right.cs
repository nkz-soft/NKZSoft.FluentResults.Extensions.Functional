namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTestsTaskRight : OnSuccessTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncExecutesTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = await result.OnSuccessTryAsync(TaskActionEmptyAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncTExecutesTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = await result.OnSuccessTryAsync(TaskActionWithValueAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    public async Task OnSuccessTryAsyncConvertsTaskExceptionToFailureWithDefaultError()
    {
        var output = await Result.Ok().OnSuccessTryAsync(ThrowTaskActionAsync);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task OnSuccessTryAsyncConvertsTaskExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok().OnSuccessTryAsync(ThrowTaskActionAsync, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task OnSuccessTryAsyncThrowsWhenFunctionIsNull()
    {
        var action = async () => await Result.Ok().OnSuccessTryAsync((Func<Task>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
