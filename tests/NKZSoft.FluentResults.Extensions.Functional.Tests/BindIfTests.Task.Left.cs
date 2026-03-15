namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindIfTestsTaskLeft : BindIfTestsBase
{
    [Test]
    public async Task BindIfTaskLeftResultConditionFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await Task.FromResult(result).BindIfAsync(false, OkFunc);

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfTaskLeftResultPredicateFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await Task.FromResult(result).BindIfAsync(FalsePredicate, OkFunc);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfTaskLeftResultTConditionTrueReturnsBoundResult()
    {
        var output = await Task.FromResult(Result.Ok(TValue.Value)).BindIfAsync(true, BindToBoundValue);

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(BoundValue);
    }

    [Test]
    public async Task BindIfTaskLeftResultTPredicateOnFailedSourceSkipsPredicateAndFunc()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await Task.FromResult(result).BindIfAsync(TruePredicate, BindToBoundValue);

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
