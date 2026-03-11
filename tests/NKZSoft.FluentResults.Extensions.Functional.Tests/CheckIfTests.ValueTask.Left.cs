namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckIfTestsValueTaskLeft : CheckIfTestsBase
{
    [Test]
    public async Task CheckIfValueTaskLeftConditionFalseReturnsOriginalResultAndSkipsCheck()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(false, () => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Test]
    public async Task CheckIfValueTaskLeftConditionTrueExecutesCheckAndReturnsFailure()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Result Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(true, Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Test]
    public async Task CheckIfValueTaskLeftPredicateFalseSkipsCheckAndReturnsOriginalResult()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(FalsePredicate, () => OkCheck());

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Test]
    public async Task CheckIfValueTaskLeftPredicateOnFailedSourceSkipsPredicateAndCheck()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).CheckIfAsync(TruePredicate, value => OkCheck(value));

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }
}
