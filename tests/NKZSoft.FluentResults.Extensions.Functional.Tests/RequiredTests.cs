namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class RequiredTests
{
    [Fact]
    public void RequiredReturnsFailureWhenValueIsNull()
    {
        var result = Result.Ok<string?>(null);

        var output = result.Required("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value is required");
    }

    [Fact]
    public void RequiredReturnsSuccessWhenReferenceValueIsNotNull()
    {
        const string value = "ok";
        var result = Result.Ok<string?>(value);

        var output = result.Required("Value is required");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(value);
    }

    [Fact]
    public void RequiredReturnsSuccessWhenNullableStructHasValue()
    {
        var result = Result.Ok<int?>(42);

        var output = result.Required("Value is required");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(42);
    }

    [Fact]
    public void RequiredReturnsFailureWhenNullableStructIsNull()
    {
        var result = Result.Ok<int?>(null);

        var output = result.Required("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value is required");
    }

    [Fact]
    public void RequiredPreservesSourceErrorsWhenSourceIsFailed()
    {
        var result = Result.Fail<string?>("Source failure");

        var output = result.Required("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Source failure");
        output.Errors.Should().NotContain(x => x.Message == "Value is required");
    }

    [Fact]
    public void RequiredThrowsWhenErrorMessageIsNull()
    {
        var result = Result.Ok<string?>("ok");

        Action act = () => result.Required(null!);

        act.Should().Throw<ArgumentNullException>();
    }
}
