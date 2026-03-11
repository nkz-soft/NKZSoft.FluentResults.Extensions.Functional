namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class EnsureNotTestsTaskLeft
{
    [Test]
    public async Task EnsureNotTaskLeftReturnsSuccessWhenPredicateIsFalse()
    {
        var resultTask = Task.FromResult(Result.Ok(5));

        var output = await resultTask.EnsureNotAsync(x => x > 10, "Value should be less than or equal to 10");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(5);
    }

    [Test]
    public async Task EnsureNotTaskLeftReturnsFailureWhenPredicateIsTrue()
    {
        var resultTask = Task.FromResult(Result.Ok(15));

        var output = await resultTask.EnsureNotAsync(x => x > 10, "Value should be less than or equal to 10");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value should be less than or equal to 10");
    }

    [Test]
    public async Task EnsureNotTaskLeftPreservesSourceErrorsWhenSourceIsFailed()
    {
        var resultTask = Task.FromResult(Result.Fail<int>("Source failure"));

        var output = await resultTask.EnsureNotAsync(x => x > 10, "Value should be less than or equal to 10");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Source failure");
        output.Errors.Should().NotContain(x => x.Message == "Value should be less than or equal to 10");
    }
}
