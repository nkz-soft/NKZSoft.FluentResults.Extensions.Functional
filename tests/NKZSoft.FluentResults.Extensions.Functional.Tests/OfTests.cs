namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OfTests : OfTestsBase
{
    [Fact]
    public void OfValueExpectedResultOkWithValue()
    {
        var output = ResultExtensions.Of(TValue.Value);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public void OfNullableValueExpectedResultOkWithNull()
    {
        var output = ResultExtensions.Of((string?)null);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeNull();
    }

    [Fact]
    public void OfFuncExpectedResultOkWithValue()
    {
        var output = ResultExtensions.Of(SuccessFunc);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public void OfFuncIsNullExpectedThrowArgumentNullException()
    {
        var action = () => ResultExtensions.Of((Func<TValue>)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void OfFuncThrowsExpectedException()
    {
        var action = () => ResultExtensions.Of(FailFunc);

        action.Should().Throw<InvalidOperationException>().WithMessage(ExceptionMessage);
    }
}
