namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CombineTests
{
    [Test]
    public void CombineReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = ResultExtensions.Combine(Result.Ok(), Result.Ok());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void CombineAggregatesErrorsFromAllFailedResults()
    {
        var output = ResultExtensions.Combine(Result.Fail("Failure 1"), Result.Fail("Failure 2"));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public void CombineReturnsSuccessWhenNoResultsProvided()
    {
        var output = ResultExtensions.Combine();

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void CombineThrowsWhenResultsArrayIsNull()
    {
        var action = () => ResultExtensions.Combine(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CombineThrowsWhenResultItemIsNull()
    {
        Result?[] inputs = [Result.Ok(), null, Result.Fail("Failure")];

        var action = () => ResultExtensions.Combine(inputs!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CombineTReturnsMergedValuesWhenAllResultsSuccessful()
    {
        var output = ResultExtensions.Combine(Result.Ok(1), Result.Ok(2));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public void CombineTReturnsFailureAndAggregatesErrors()
    {
        var output = ResultExtensions.Combine(Result.Ok(1), Result.Fail<int>("Failure"));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(e => e.Message == "Failure");
    }
}
