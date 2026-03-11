namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureNotTests
{
    [Test]
    public void EnsureNotReturnsSuccessWhenPredicateIsFalse()
    {
        var result = Result.Ok(5);

        var output = result.EnsureNot(x => x > 10, "Value should be less than or equal to 10");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(5);
    }

    [Test]
    public void EnsureNotReturnsFailureWhenPredicateIsTrue()
    {
        var result = Result.Ok(15);

        var output = result.EnsureNot(x => x > 10, "Value should be less than or equal to 10");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value should be less than or equal to 10");
    }

    [Test]
    public void EnsureNotPreservesSourceErrorsWhenSourceIsFailed()
    {
        var result = Result.Fail<int>("Source failure");

        var output = result.EnsureNot(x => x > 10, "Value should be less than or equal to 10");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Source failure");
        output.Errors.Should().NotContain(x => x.Message == "Value should be less than or equal to 10");
    }

    [Test]
    public void EnsureNotThrowsWhenPredicateIsNull()
    {
        var result = Result.Ok(5);

        Action act = () => result.EnsureNot(null!, "Value should be less than or equal to 10");

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void EnsureNotThrowsWhenErrorMessageIsNull()
    {
        var result = Result.Ok(5);

        Action act = () => result.EnsureNot(x => x > 10, null!);

        act.Should().Throw<ArgumentNullException>();
    }
}
