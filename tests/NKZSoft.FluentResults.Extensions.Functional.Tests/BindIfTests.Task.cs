namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindIfTestsTask : BindIfTestsBase
{
    [Test]
    public async Task BindIfTaskResultConditionFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await Task.FromResult(result).BindIfAsync(false, TaskOkFuncAsync);

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfTaskResultPredicateFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = await Task.FromResult(result).BindIfAsync(FalsePredicate, TaskOkFuncAsync);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task BindIfTaskResultTConditionTrueReturnsBoundResult()
    {
        var output = await Task.FromResult(Result.Ok(TValue.Value)).BindIfAsync(true, TaskBindToBoundValueAsync);

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(BoundValue);
    }

    [Test]
    public async Task BindIfTaskResultTConditionTruePropagatesFailure()
    {
        var output = await Task.FromResult(Result.Ok(TValue.Value)).BindIfAsync(true, TaskFailBindAsync);

        FuncExecuted.Should().BeTrue();
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
