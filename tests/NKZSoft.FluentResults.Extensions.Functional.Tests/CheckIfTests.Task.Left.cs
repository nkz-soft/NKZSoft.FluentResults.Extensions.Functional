namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckIfTestsTaskLeft : CheckIfTestsBase
{
    [Fact]
    public async Task CheckIfTaskLeftConditionFalseReturnsOriginalResultAndSkipsCheck()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).CheckIfAsync(false, () => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public async Task CheckIfTaskLeftConditionTrueExecutesCheckAndReturnsFailure()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Result Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = await Task.FromResult(result).CheckIfAsync(true, Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public async Task CheckIfTaskLeftPredicateFalseSkipsCheckAndReturnsOriginalResult()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).CheckIfAsync(FalsePredicate, () => OkCheck());

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public async Task CheckIfTaskLeftPredicateOnFailedSourceSkipsPredicateAndCheck()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await Task.FromResult(result).CheckIfAsync(TruePredicate, value => OkCheck(value));

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }
}
