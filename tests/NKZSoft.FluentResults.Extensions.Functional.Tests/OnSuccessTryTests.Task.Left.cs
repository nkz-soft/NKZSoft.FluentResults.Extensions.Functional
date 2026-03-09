namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTestsTaskLeft : OnSuccessTryTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task OnSuccessTryAsyncExecutesActionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();

        var output = await resultTask.OnSuccessTryAsync(ActionEmpty);

        AssertState(output, isSuccess, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task OnSuccessTryAsyncTExecutesActionOnlyWhenTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();

        var output = await resultTask.OnSuccessTryAsync(ActionWithValue);

        AssertState(output, isSuccess, isSuccess);
    }

    [Fact]
    public async Task OnSuccessTryAsyncConvertsExceptionToFailureWithCustomError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .OnSuccessTryAsync(ThrowAction, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Fact]
    public async Task OnSuccessTryAsyncThrowsWhenActionIsNull()
    {
        var action = async () => await ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask()
            .OnSuccessTryAsync(null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
