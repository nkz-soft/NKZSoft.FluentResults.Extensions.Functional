namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckIfTestsValueTaskRight : CheckIfTestsBase
{
    [Fact]
    public async Task CheckIfValueTaskRightConditionFalseReturnsOriginalResultAndSkipsCheck()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CheckIfAsync(false, () => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public async Task CheckIfValueTaskRightConditionTrueExecutesCheckAndReturnsFailure()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        ValueTask<Result> Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return ValueTask.FromResult(checkResult);
        }

        var output = await result.CheckIfAsync(true, Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public async Task CheckIfValueTaskRightPredicateFalseSkipsCheckAndReturnsOriginalResult()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CheckIfAsync(FalsePredicate, () => ValueTaskOkCheckAsync());

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public async Task CheckIfValueTaskRightPredicateOnFailedSourceSkipsPredicateAndCheck()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.CheckIfAsync(TruePredicate, value => ValueTaskOkCheckAsync(value));

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }
}
