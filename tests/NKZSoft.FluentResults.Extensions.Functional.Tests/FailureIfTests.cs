namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FailureIfTests
{
    [Fact]
    public void FailureIfBoolReturnsFailWhenConditionTrue()
    {
        var output = ResultExtensions.FailureIf(true, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public void FailureIfBoolReturnsOkWhenConditionFalse()
    {
        var output = ResultExtensions.FailureIf(false, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void FailureIfBoolWithValueReturnsFailWhenConditionTrue()
    {
        var output = ResultExtensions.FailureIf(true, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public void FailureIfBoolWithValueReturnsOkWithValueWhenConditionFalse()
    {
        var value = new object();
        var output = ResultExtensions.FailureIf(false, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Fact]
    public void FailureIfPredicateReturnsFailWhenPredicateReturnsTrue()
    {
        var output = ResultExtensions.FailureIf(() => true, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public void FailureIfPredicateReturnsOkWhenPredicateReturnsFalse()
    {
        var output = ResultExtensions.FailureIf(() => false, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void FailureIfPredicateWithValueReturnsFailWhenPredicateReturnsTrue()
    {
        var output = ResultExtensions.FailureIf(() => true, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public void FailureIfPredicateWithValueReturnsOkWithValueWhenPredicateReturnsFalse()
    {
        var value = new object();
        var output = ResultExtensions.FailureIf(() => false, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Fact]
    public void FailureIfPredicateThrowsWhenPredicateIsNull()
    {
        var action = () => ResultExtensions.FailureIf((Func<bool>)null!, "error");

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void FailureIfPredicateWithValueThrowsWhenPredicateIsNull()
    {
        var action = () => ResultExtensions.FailureIf((Func<bool>)null!, 10, "error");

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public async Task FailureIfAsyncBoolReturnsFailWhenConditionTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(true, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public async Task FailureIfAsyncBoolReturnsOkWhenConditionFalse()
    {
        var output = await ResultExtensions.FailureIfAsync(false, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task FailureIfAsyncBoolWithValueReturnsFailWhenConditionTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(true, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public async Task FailureIfAsyncBoolWithValueReturnsOkWithValueWhenConditionFalse()
    {
        var value = new object();
        var output = await ResultExtensions.FailureIfAsync(false, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }
}
