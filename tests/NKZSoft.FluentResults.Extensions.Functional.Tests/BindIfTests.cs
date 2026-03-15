namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindIfTests : BindIfTestsBase
{
    [Test]
    public void BindIfResultConditionFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok();

        var output = result.BindIf(false, OkFunc);

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public void BindIfResultConditionTrueExecutesFuncAndReturnsBoundResult()
    {
        var output = Result.Ok().BindIf(true, OkFunc);

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void BindIfResultPredicateOnFailedSourceSkipsPredicateAndFunc()
    {
        var result = Result.Fail(ErrorMessage);

        var output = result.BindIf(TruePredicate, OkFunc);

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }

    [Test]
    public void BindIfResultTPredicateFalseReturnsOriginalResultAndSkipsFunc()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.BindIf(FalsePredicate, BindToBoundValue);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public void BindIfResultTPredicateTrueReturnsBoundResult()
    {
        var output = Result.Ok(TValue.Value).BindIf(TruePredicate, BindToBoundValue);

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(BoundValue);
    }

    [Test]
    public void BindIfResultTConditionTruePropagatesFuncFailure()
    {
        var output = Result.Ok(TValue.Value).BindIf(true, FailBind);

        FuncExecuted.Should().BeTrue();
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
