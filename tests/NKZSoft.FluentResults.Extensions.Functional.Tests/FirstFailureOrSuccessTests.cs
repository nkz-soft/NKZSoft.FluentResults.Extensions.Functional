namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FirstFailureOrSuccessTests
{
    [Test]
    public void FirstFailureOrSuccessReturnsFirstFailedResult()
    {
        var firstSuccess = Result.Ok();
        var firstFailure = Result.Fail("Failure 1");
        var secondFailure = Result.Fail("Failure 2");

        var output = ResultExtensions.FirstFailureOrSuccess(firstSuccess, firstFailure, secondFailure);

        output.IsFailed.Should().BeTrue();
        output.Should().BeSameAs(firstFailure);
        output.Errors.Should().ContainSingle(error => error.Message == "Failure 1");
    }

    [Test]
    public void FirstFailureOrSuccessReturnsSuccessWhenAllAreSuccessful()
    {
        var output = ResultExtensions.FirstFailureOrSuccess(Result.Ok(), Result.Ok(), Result.Ok());

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void FirstFailureOrSuccessReturnsSuccessWhenNoResultsProvided()
    {
        var output = ResultExtensions.FirstFailureOrSuccess();

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void FirstFailureOrSuccessThrowsWhenResultsArrayIsNull()
    {
        var action = () => ResultExtensions.FirstFailureOrSuccess(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void FirstFailureOrSuccessThrowsWhenResultItemIsNull()
    {
        Result?[] inputs = [Result.Ok(), null, Result.Fail("Failure")];

        var action = () => ResultExtensions.FirstFailureOrSuccess(inputs!);

        action.Should().Throw<ArgumentNullException>();
    }
}
