namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckIfTestsTask : CheckIfTestsBase
{
    [Fact]
    public async Task CheckIfTaskConditionFalseReturnsOriginalResultAndSkipsCheck()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).CheckIfAsync(false, () => TaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public async Task CheckIfTaskConditionTrueExecutesCheckAndReturnsFailure()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Task<Result> Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return Task.FromResult(checkResult);
        }

        var output = await Task.FromResult(result).CheckIfAsync(true, Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public async Task CheckIfTaskPredicateFalseSkipsCheckAndReturnsOriginalResult()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).CheckIfAsync(FalsePredicate, () => TaskOkCheckAsync());

        PredicateExecuted.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }

    [Fact]
    public async Task CheckIfTaskPredicateOnFailedSourceSkipsPredicateAndCheck()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await Task.FromResult(result).CheckIfAsync(TruePredicate, value => TaskOkCheckAsync(value));

        PredicateExecuted.Should().BeFalse();
        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
    }
}
