namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapIfTestsTaskLeft : MapIfTestsBase
{
    [Test]
    public async Task MapIfTaskLeftConditionFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).MapIfAsync(false, MapFunc);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfTaskLeftConditionTrueMapsValue()
    {
        var output = await Task.FromResult(Result.Ok(TValue.Value)).MapIfAsync(true, MapFunc);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfTaskLeftPredicateFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).MapIfAsync(FalsePredicate, MapFunc);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfTaskLeftPredicateOnFailedSourceSkipsPredicateAndMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await Task.FromResult(result).MapIfAsync(TruePredicate, MapFunc);

        AssertSkipped(result, output, predicateExecuted: false);
    }
}
