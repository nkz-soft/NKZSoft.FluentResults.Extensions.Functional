namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TryTests : TryTestsBase
{
    [Fact]
    public void TryActionIsSuccessfulExpectedResultOk()
    {
        var output = ResultExtensions.Try(SuccessAction);

        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void TryActionThrowsExpectedResultFailWithDefaultError()
    {
        var output = ResultExtensions.Try(FailAction);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Fact]
    public void TryActionThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = ResultExtensions.Try(FailAction, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Fact]
    public void TryActionIsNullExpectedThrowArgumentNullException()
    {
        var action = () => ResultExtensions.Try(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void TryFuncIsSuccessfulExpectedResultOkWithValue()
    {
        var output = ResultExtensions.Try(SuccessFunc);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public void TryFuncThrowsExpectedResultFailWithDefaultError()
    {
        var output = ResultExtensions.Try(FailFunc);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Fact]
    public void TryFuncThrowsAndCustomErrorHandlerExpectedResultFailWithCustomError()
    {
        var output = ResultExtensions.Try(FailFunc, CustomErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Fact]
    public void TryFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = () => ResultExtensions.Try<TValue>(null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
