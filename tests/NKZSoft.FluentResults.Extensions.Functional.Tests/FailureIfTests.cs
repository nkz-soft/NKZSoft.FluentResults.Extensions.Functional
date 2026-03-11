namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FailureIfTests
{
    [Test]
    public void FailureIfBoolReturnsFailWhenConditionTrue()
    {
        var output = ResultExtensions.FailureIf(true, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void FailureIfBoolReturnsOkWhenConditionFalse()
    {
        var output = ResultExtensions.FailureIf(false, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void FailureIfBoolWithValueReturnsFailWhenConditionTrue()
    {
        var output = ResultExtensions.FailureIf(true, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void FailureIfBoolWithValueReturnsOkWithValueWhenConditionFalse()
    {
        var value = new object();
        var output = ResultExtensions.FailureIf(false, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Test]
    public void FailureIfPredicateReturnsFailWhenPredicateReturnsTrue()
    {
        var output = ResultExtensions.FailureIf(() => true, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void FailureIfPredicateReturnsOkWhenPredicateReturnsFalse()
    {
        var output = ResultExtensions.FailureIf(() => false, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void FailureIfPredicateWithValueReturnsFailWhenPredicateReturnsTrue()
    {
        var output = ResultExtensions.FailureIf(() => true, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void FailureIfPredicateWithValueReturnsOkWithValueWhenPredicateReturnsFalse()
    {
        var value = new object();
        var output = ResultExtensions.FailureIf(() => false, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Test]
    public void FailureIfPredicateThrowsWhenPredicateIsNull()
    {
        var action = () => ResultExtensions.FailureIf((Func<bool>)null!, "error");

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void FailureIfPredicateWithValueThrowsWhenPredicateIsNull()
    {
        var action = () => ResultExtensions.FailureIf((Func<bool>)null!, 10, "error");

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task FailureIfAsyncBoolReturnsFailWhenConditionTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(true, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task FailureIfAsyncBoolReturnsOkWhenConditionFalse()
    {
        var output = await ResultExtensions.FailureIfAsync(false, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task FailureIfAsyncBoolWithValueReturnsFailWhenConditionTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(true, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task FailureIfAsyncBoolWithValueReturnsOkWithValueWhenConditionFalse()
    {
        var value = new object();
        var output = await ResultExtensions.FailureIfAsync(false, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }
}
