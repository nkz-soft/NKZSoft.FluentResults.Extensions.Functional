namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TryTestsTask : TryTestsBase
{
    [Test]
    public async Task TryAsyncTaskActionIsSuccessfulExpectedResultOk()
    {
        var output = await ResultExtensions.TryAsync(SuccessTaskAction);

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TryAsyncTaskActionThrowsExpectedResultFailWithDefaultError()
    {
        var output = await ResultExtensions.TryAsync(FailTaskAction);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task TryAsyncTaskActionThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = await ResultExtensions.TryAsync(FailTaskAction, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task TryAsyncTaskActionIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.TryAsync((Func<Task>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task TryAsyncTaskFuncIsSuccessfulExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.TryAsync(SuccessTaskFunc);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task TryAsyncTaskFuncThrowsExpectedResultFailWithDefaultError()
    {
        var output = await ResultExtensions.TryAsync(FailTaskFunc);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public async Task TryAsyncTaskFuncThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = await ResultExtensions.TryAsync(FailTaskFunc, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public async Task TryAsyncTaskFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.TryAsync<TValue>((Func<Task<TValue>>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
