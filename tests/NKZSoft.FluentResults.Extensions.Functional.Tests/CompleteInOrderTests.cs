namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompleteInOrderTests
{
    [Test]
    public void CompleteInOrderReturnsSuccessWhenAllResultsSuccessful()
    {
        var output = ResultExtensions.CompleteInOrder(Result.Ok(), Result.Ok());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void CompleteInOrderAggregatesErrorsFromAllFailedResults()
    {
        var output = ResultExtensions.CompleteInOrder(Result.Fail("Failure 1"), Result.Fail("Failure 2"));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == "Failure 1");
        output.Errors.Should().Contain(e => e.Message == "Failure 2");
    }

    [Test]
    public void CompleteInOrderReturnsSuccessWhenNoResultsProvided()
    {
        var output = ResultExtensions.CompleteInOrder();

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void CompleteInOrderThrowsWhenResultsArrayIsNull()
    {
        var action = () => ResultExtensions.CompleteInOrder(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CompleteInOrderThrowsWhenResultItemIsNull()
    {
        Result?[] inputs = [Result.Ok(), null, Result.Fail("Failure")];

        var action = () => ResultExtensions.CompleteInOrder(inputs!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CompleteInOrderTReturnsMergedValuesWhenAllResultsSuccessful()
    {
        var output = ResultExtensions.CompleteInOrder(Result.Ok(1), Result.Ok(2));

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Equal(1, 2);
    }

    [Test]
    public void CompleteInOrderTReturnsFailureAndAggregatesErrors()
    {
        var output = ResultExtensions.CompleteInOrder(Result.Ok(1), Result.Fail<int>("Failure"));

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(e => e.Message == "Failure");
    }
}
