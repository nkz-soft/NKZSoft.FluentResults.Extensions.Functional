namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OfTestsValueTask : OfTestsBase
{
    [Test]
    public async Task OfAsyncValueTaskExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.OfAsync(SuccessValueTask());

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task OfAsyncValueTaskThrowsExpectedException()
    {
        var action = async () => await ResultExtensions.OfAsync(FailValueTask());

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(ExceptionMessage);
    }

    [Test]
    public async Task OfAsyncValueTaskFuncExpectedResultOkWithValue()
    {
        var output = await ResultExtensions.OfAsync(SuccessValueTask);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task OfAsyncValueTaskFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = async () => await ResultExtensions.OfAsync((Func<ValueTask<TValue>>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task OfAsyncValueTaskFuncThrowsExpectedException()
    {
        var action = async () => await ResultExtensions.OfAsync(FailValueTask);

        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(ExceptionMessage);
    }
}
