namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureNotNullTests
{
    [Fact]
    public void EnsureNotNullReturnsFailureWhenValueIsNull()
    {
        var result = Result.Ok<string?>(null);

        var output = result.EnsureNotNull("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value is required");
    }

    [Fact]
    public void EnsureNotNullReturnsSuccessWhenReferenceValueIsNotNull()
    {
        const string value = "ok";
        var result = Result.Ok<string?>(value);

        var output = result.EnsureNotNull("Value is required");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(value);
    }

    [Fact]
    public void EnsureNotNullReturnsSuccessWhenNullableStructHasValue()
    {
        var result = Result.Ok<int?>(42);

        var output = result.EnsureNotNull("Value is required");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(42);
    }

    [Fact]
    public void EnsureNotNullReturnsFailureWhenNullableStructIsNull()
    {
        var result = Result.Ok<int?>(null);

        var output = result.EnsureNotNull("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value is required");
    }

    [Fact]
    public void EnsureNotNullPreservesSourceErrorsWhenSourceIsFailed()
    {
        var result = Result.Fail<string?>("Source failure");

        var output = result.EnsureNotNull("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Source failure");
        output.Errors.Should().NotContain(x => x.Message == "Value is required");
    }

    [Fact]
    public void EnsureNotNullThrowsWhenErrorMessageIsNull()
    {
        var result = Result.Ok<string?>("ok");

        Action act = () => result.EnsureNotNull(null!);

        act.Should().Throw<ArgumentNullException>();
    }
}
