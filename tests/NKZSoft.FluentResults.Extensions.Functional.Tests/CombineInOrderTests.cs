namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CombineInOrderTests
{
    [Test]
    public void CombineInOrderReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = ResultExtensions.CombineInOrder(Result.Ok(), Result.Ok());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void CombineInOrderAggregatesErrorsFromAllFailedResults()
    {
        var output = ResultExtensions.CombineInOrder(Result.Fail("Failure 1"), Result.Fail("Failure 2"));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public void CombineInOrderReturnsSuccessWhenNoResultsProvided()
    {
        var output = ResultExtensions.CombineInOrder();

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void CombineInOrderThrowsWhenResultsArrayIsNull()
    {
        var action = () => ResultExtensions.CombineInOrder(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CombineInOrderThrowsWhenResultItemIsNull()
    {
        Result?[] inputs = [Result.Ok(), null, Result.Fail("Failure")];

        var action = () => ResultExtensions.CombineInOrder(inputs!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CombineInOrderTReturnsMergedValuesWhenAllResultsSuccessful()
    {
        var output = ResultExtensions.CombineInOrder(Result.Ok(1), Result.Ok(2));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public void CombineInOrderTReturnsFailureAndAggregatesErrors()
    {
        var output = ResultExtensions.CombineInOrder(Result.Ok(1), Result.Fail<int>("Failure"));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(e => e.Message == "Failure");
    }
}
