namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindIfTestsValueTaskLeft : BindIfTestsBase
{
    [Test]
    public async Task BindIfValueTaskLeftResultConditionFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).BindIfAsync(false, OkFunc);

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfValueTaskLeftResultPredicateFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).BindIfAsync(FalsePredicate, OkFunc);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfValueTaskLeftResultTConditionTrueReturnsBoundResult()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Ok(TValue.Value)).BindIfAsync(true, BindToBoundValue);

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(BoundValue);
    }

    [Test]
    public async Task BindIfValueTaskLeftResultTPredicateOnFailedSourceSkipsPredicateAndFunc()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).BindIfAsync(TruePredicate, BindToBoundValue);

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
