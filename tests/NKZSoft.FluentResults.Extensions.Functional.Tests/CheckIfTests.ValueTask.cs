namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckIfTestsValueTask : CheckIfTestsBase
{
    [Test]
    public async Task CheckIfValueTaskConditionFalseReturnsOriginalResultAndSkipsCheck()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(false, () => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Test]
    public async Task CheckIfValueTaskConditionTrueExecutesCheckAndReturnsFailure()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        ValueTask<Result> Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return ValueTask.FromResult(checkResult);
        }

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(true, Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Test]
    public async Task CheckIfValueTaskPredicateFalseSkipsCheckAndReturnsOriginalResult()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(FalsePredicate, () => ValueTaskOkCheckAsync());

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Test]
    public async Task CheckIfValueTaskPredicateOnFailedSourceSkipsPredicateAndCheck()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(TruePredicate, value => ValueTaskOkCheckAsync(value));

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }
}
