namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapIfTestsValueTaskLeft : MapIfTestsBase
{
    [Test]
    public async Task MapIfValueTaskLeftConditionFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(false, MapFunc);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfValueTaskLeftConditionTrueMapsValue()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Ok(TValue.Value)).MapIfAsync(true, MapFunc);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfValueTaskLeftPredicateFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(FalsePredicate, MapFunc);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfValueTaskLeftPredicateOnFailedSourceSkipsPredicateAndMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(TruePredicate, MapFunc);

        AssertSkipped(result, output, predicateExecuted: false);
    }
}
