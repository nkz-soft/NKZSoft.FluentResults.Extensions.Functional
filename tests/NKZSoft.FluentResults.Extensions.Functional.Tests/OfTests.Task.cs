namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OfTestsTask : OfTestsBase
{
    [Fact]
    public async Task OfAsyncTaskExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.OfAsync(SuccessTask());

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task OfAsyncTaskIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.OfAsync((Task<TValue>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task OfAsyncTaskThrowsExpectedException()
    {
        var action = async () => await ResultExtensions.OfAsync(FailTask());

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(ExceptionMessage);
    }

    [Fact]
    public async Task OfAsyncTaskFuncExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.OfAsync(SuccessTask);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task OfAsyncTaskFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.OfAsync((Func<Task<TValue>>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task OfAsyncTaskFuncThrowsExpectedException()
    {
        var action = async () => await ResultExtensions.OfAsync(FailTask);

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(ExceptionMessage);
    }
}
