namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SuccessIfTests
{
    [Test]
    public void SuccessIfBoolReturnsOkWhenConditionTrue()
    {
        var output = ResultExtensions.SuccessIf(true, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void SuccessIfBoolReturnsFailWhenConditionFalse()
    {
        var output = ResultExtensions.SuccessIf(false, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void SuccessIfBoolWithValueReturnsOkWithValueWhenConditionTrue()
    {
        var value = new object();
        var output = ResultExtensions.SuccessIf(true, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Test]
    public void SuccessIfBoolWithValueReturnsFailWhenConditionFalse()
    {
        var output = ResultExtensions.SuccessIf(false, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void SuccessIfPredicateReturnsOkWhenPredicateReturnsTrue()
    {
        var output = ResultExtensions.SuccessIf(() => true, "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void SuccessIfPredicateReturnsFailWhenPredicateReturnsFalse()
    {
        var output = ResultExtensions.SuccessIf(() => false, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void SuccessIfPredicateWithValueReturnsOkWithValueWhenPredicateReturnsTrue()
    {
        var value = new object();
        var output = ResultExtensions.SuccessIf(() => true, value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Test]
    public void SuccessIfPredicateWithValueReturnsFailWhenPredicateReturnsFalse()
    {
        var output = ResultExtensions.SuccessIf(() => false, 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public void SuccessIfPredicateThrowsWhenPredicateIsNull()
    {
        var action = () => ResultExtensions.SuccessIf((Func<bool>)null!, "error");

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void SuccessIfPredicateWithValueThrowsWhenPredicateIsNull()
    {
        var action = () => ResultExtensions.SuccessIf((Func<bool>)null!, 10, "error");

        action.Should().Throw<ArgumentNullException>();
    }
}
