namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTestsTaskLeft : OnSuccessTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncExecutesActionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();

        var output = await resultTask.OnSuccessTryAsync(ActionEmpty);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncTExecutesActionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();

        var output = await resultTask.OnSuccessTryAsync(ActionWithValue);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    public async Task OnSuccessTryAsyncConvertsExceptionToFailureWithCustomError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .OnSuccessTryAsync(ThrowAction, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task OnSuccessTryAsyncThrowsWhenActionIsNull()
    {
        var action = async () => await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .OnSuccessTryAsync(null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
