namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TryTests : TryTestsBase
{
    [Test]
    public void TryActionIsSuccessfulExpectedResultOk()
    {
        var output = ResultExtensions.Try(SuccessAction);

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void TryActionThrowsExpectedResultFailWithDefaultError()
    {
        var output = ResultExtensions.Try(FailAction);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public void TryActionThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = ResultExtensions.Try(FailAction, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public void TryActionIsNullExpectedThrowArgumentNullException()
    {
        var action = () => ResultExtensions.Try(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void TryFuncIsSuccessfulExpectedResultOkWithValue()
    {
        var output = ResultExtensions.Try(SuccessFunc);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public void TryFuncThrowsExpectedResultFailWithDefaultError()
    {
        var output = ResultExtensions.Try(FailFunc);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Test]
    public void TryFuncThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = ResultExtensions.Try(FailFunc, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Test]
    public void TryFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = () => ResultExtensions.Try<TValue>(null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
