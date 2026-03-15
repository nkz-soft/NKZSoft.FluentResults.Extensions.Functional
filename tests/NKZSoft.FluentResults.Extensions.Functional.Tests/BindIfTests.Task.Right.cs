namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindIfTestsTaskRight : BindIfTestsBase
{
    [Test]
    public async Task BindIfTaskRightResultConditionFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await result.BindIfAsync(false, TaskOkFuncAsync);

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfTaskRightResultPredicateFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await result.BindIfAsync(FalsePredicate, TaskOkFuncAsync);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfTaskRightResultTConditionTrueReturnsBoundResult()
    {
        var output = await Result.Ok(TValue.Value).BindIfAsync(true, TaskBindToBoundValueAsync);

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(BoundValue);
    }

    [Test]
    public async Task BindIfTaskRightResultTPredicateOnFailedSourceSkipsPredicateAndFunc()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.BindIfAsync(TruePredicate, TaskBindToBoundValueAsync);

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
