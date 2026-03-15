namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindIfTestsValueTaskRight : BindIfTestsBase
{
    [Test]
    public async Task BindIfValueTaskRightResultConditionFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await result.BindIfAsync(false, ValueTaskOkFuncAsync);

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfValueTaskRightResultPredicateFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await result.BindIfAsync(FalsePredicate, ValueTaskOkFuncAsync);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfValueTaskRightResultTConditionTrueReturnsBoundResult()
    {
        var output = await Result.Ok(TValue.Value).BindIfAsync(true, ValueTaskBindToBoundValueAsync);

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(BoundValue);
    }

    [Test]
    public async Task BindIfValueTaskRightResultTPredicateOnFailedSourceSkipsPredicateAndFunc()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.BindIfAsync(TruePredicate, ValueTaskBindToBoundValueAsync);

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
