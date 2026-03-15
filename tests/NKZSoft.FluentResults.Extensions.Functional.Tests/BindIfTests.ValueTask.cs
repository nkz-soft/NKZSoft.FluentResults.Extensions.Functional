namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindIfTestsValueTask : BindIfTestsBase
{
    [Test]
    public async Task BindIfValueTaskResultConditionFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).BindIfAsync(false, ValueTaskOkFuncAsync);

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfValueTaskResultPredicateFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).BindIfAsync(FalsePredicate, ValueTaskOkFuncAsync);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfValueTaskResultTConditionTrueReturnsBoundResult()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Ok(TValue.Value)).BindIfAsync(true, ValueTaskBindToBoundValueAsync);

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(BoundValue);
    }

    [Test]
    public async Task BindIfValueTaskResultTConditionTruePropagatesFailure()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Ok(TValue.Value)).BindIfAsync(true, ValueTaskFailBindAsync);

        FuncExecuted.Should().BeTrue();
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
