namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTestsValueTaskLeft : OnSuccessTryTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncExecutesActionOnlyWhenValueTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);

        var output = await resultTask.OnSuccessTryAsync(ActionEmpty);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task OnSuccessTryAsyncTExecutesActionOnlyWhenValueTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);

        var output = await resultTask.OnSuccessTryAsync(ActionWithValue);

        AssertState(output, isSuccess, isSuccess);
    }

    [Test]
    public async Task OnSuccessTryAsyncConvertsExceptionToFailureWithDefaultError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .OnSuccessTryAsync(ThrowAction);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task OnSuccessTryAsyncConvertsExceptionToFailureWithCustomError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .OnSuccessTryAsync(ThrowAction, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task OnSuccessTryAsyncThrowsWhenActionIsNull()
    {
        var action = async () => await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .OnSuccessTryAsync((Action)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
