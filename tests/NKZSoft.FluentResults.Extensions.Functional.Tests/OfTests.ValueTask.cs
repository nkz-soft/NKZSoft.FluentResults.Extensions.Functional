namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OfTestsValueTask : OfTestsBase
{
    [Fact]
    public async Task OfAsyncValueTaskExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.OfAsync(SuccessValueTask());

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task OfAsyncValueTaskThrowsExpectedException()
    {
        var action = async () => await ResultExtensions.OfAsync(FailValueTask());

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(ExceptionMessage);
    }

    [Fact]
    public async Task OfAsyncValueTaskFuncExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.OfAsync(SuccessValueTask);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task OfAsyncValueTaskFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.OfAsync((Func<ValueTask<TValue>>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task OfAsyncValueTaskFuncThrowsExpectedException()
    {
        var action = async () => await ResultExtensions.OfAsync(FailValueTask);

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(ExceptionMessage);
    }
}
