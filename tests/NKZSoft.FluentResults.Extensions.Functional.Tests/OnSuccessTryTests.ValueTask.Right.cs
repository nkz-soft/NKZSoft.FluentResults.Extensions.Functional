namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTestsValueTaskRight : OnSuccessTryTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task OnSuccessTryAsyncExecutesValueTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = await result.OnSuccessTryAsync(ValueTaskActionEmptyAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task OnSuccessTryAsyncTExecutesValueTaskFunctionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = await result.OnSuccessTryAsync(ValueTaskActionWithValueAsync);

        AssertState(output, isSuccess, isSuccess);
    }

    [Fact]
    public async Task OnSuccessTryAsyncConvertsValueTaskExceptionToFailureWithDefaultError()
    {
        var output = await Result.Ok().OnSuccessTryAsync(ThrowValueTaskActionAsync);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Fact]
    public async Task OnSuccessTryAsyncConvertsValueTaskExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok().OnSuccessTryAsync(ThrowValueTaskActionAsync, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Fact]
    public async Task OnSuccessTryAsyncThrowsWhenFunctionIsNull()
    {
        var action = async () => await Result.Ok().OnSuccessTryAsync((Func<ValueTask>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
