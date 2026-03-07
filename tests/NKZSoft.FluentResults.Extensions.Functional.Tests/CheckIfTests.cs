namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckIfTests : CheckIfTestsBase
{
    [Fact]
    public void CheckIfConditionFalseReturnsOriginalResultAndSkipsCheck()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.CheckIf(false, () => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public void CheckIfConditionTrueExecutesCheckAndReturnsFailure()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Result Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = result.CheckIf(true, Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public void CheckIfPredicateFalseSkipsCheckAndReturnsOriginalResult()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.CheckIf(FalsePredicate, () => OkCheck());

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public void CheckIfPredicateOnFailedSourceSkipsPredicateAndCheck()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = result.CheckIf(TruePredicate, value => OkCheck(value));

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }
}
