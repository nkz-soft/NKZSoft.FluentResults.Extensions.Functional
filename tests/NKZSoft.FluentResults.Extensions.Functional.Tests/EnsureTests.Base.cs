namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class EnsureTestsBase : TestBase
{
    protected const string FailErrorMessage = "Fail Error Message";

    protected static void AssertSameResults(Result result, Result output, bool isOutputSuccess)
    {
        result.Should().Be(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }

    protected static void AssertSameResults(Result<TValue> result, Result<TValue> output, bool isOutputSuccess)
    {
        result.Should().Be(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }

    protected static void AssertDifferentResults(Result result, Result output, bool isOutputSuccess)
    {
        result.Should().NotBe(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }

    protected static void AssertDifferentResults(Result<TValue> result, Result<TValue> output, bool isOutputSuccess)
    {
        result.Should().NotBe(output);
        output.IsSuccess.Should().Be(isOutputSuccess);
    }
}
