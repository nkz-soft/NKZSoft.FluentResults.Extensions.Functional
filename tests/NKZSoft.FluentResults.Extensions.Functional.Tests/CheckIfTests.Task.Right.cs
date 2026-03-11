namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckIfTestsTaskRight : CheckIfTestsBase
{
    [Test]
    public async Task CheckIfTaskRightConditionFalseReturnsOriginalResultAndSkipsCheck()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CheckIfAsync(false, () => TaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Test]
    public async Task CheckIfTaskRightConditionTrueExecutesCheckAndReturnsFailure()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Task<Result> Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return Task.FromResult(checkResult);
        }

        var output = await result.CheckIfAsync(true, Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Test]
    public async Task CheckIfTaskRightPredicateFalseSkipsCheckAndReturnsOriginalResult()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CheckIfAsync(FalsePredicate, () => TaskOkCheckAsync());

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Test]
    public async Task CheckIfTaskRightPredicateOnFailedSourceSkipsPredicateAndCheck()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.CheckIfAsync(TruePredicate, value => TaskOkCheckAsync(value));

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }
}
