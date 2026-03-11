namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TryTestsValueTask : TryTestsBase
{
    [Test]
    public async Task TryAsyncValueTaskActionIsSuccessfulExpectedResultOk()
    {
        var output = await ResultExtensions.TryAsync(SuccessValueTaskAction);

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TryAsyncValueTaskActionThrowsExpectedResultFailWithDefaultError()
    {
        var output = await ResultExtensions.TryAsync(FailValueTaskAction);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task TryAsyncValueTaskActionThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = await ResultExtensions.TryAsync(FailValueTaskAction, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task TryAsyncValueTaskActionIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.TryAsync((Func<ValueTask>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task TryAsyncValueTaskFuncIsSuccessfulExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.TryAsync(SuccessValueTaskFunc);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task TryAsyncValueTaskFuncThrowsExpectedResultFailWithDefaultError()
    {
        var output = await ResultExtensions.TryAsync(FailValueTaskFunc);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task TryAsyncValueTaskFuncThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = await ResultExtensions.TryAsync(FailValueTaskFunc, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task TryAsyncValueTaskFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.TryAsync<TValue>((Func<ValueTask<TValue>>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
