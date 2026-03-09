namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTestsValueTask : OnSuccessTryTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task OnSuccessTryAsyncExecutesValueTaskFunctionOnlyWhenValueTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);

        var output = await resultTask.OnSuccessTryAsync(ValueTaskActionEmptyAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task OnSuccessTryAsyncTExecutesValueTaskFunctionOnlyWhenValueTaskResultIsSuccessful(bool isSuccess)
    {
        var resultTask = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);

        var output = await resultTask.OnSuccessTryAsync(ValueTaskActionWithValueAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Fact]
    public async Task OnSuccessTryAsyncConvertsValueTaskExceptionToFailureWithDefaultError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .OnSuccessTryAsync(ThrowValueTaskActionAsync);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Fact]
    public async Task OnSuccessTryAsyncConvertsValueTaskExceptionToFailureWithCustomError()
    {
        var output = await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .OnSuccessTryAsync(ThrowValueTaskActionAsync, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Fact]
    public async Task OnSuccessTryAsyncThrowsWhenFunctionIsNull()
    {
        var action = async () => await ResultExtensions.OkIfAsync(true, ErrorMessage)
            .OnSuccessTryAsync((Func<ValueTask>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
