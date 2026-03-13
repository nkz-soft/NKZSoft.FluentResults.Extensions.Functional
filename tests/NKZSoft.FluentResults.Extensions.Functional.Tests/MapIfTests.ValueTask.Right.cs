namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapIfTestsValueTaskRight : MapIfTestsBase
{
    [Test]
    public async Task MapIfValueTaskRightConditionFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.MapIfAsync(false, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfValueTaskRightConditionTrueMapsValue()
    {
        var output = await Result.Ok(TValue.Value).MapIfAsync(true, ValueTaskMapFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfValueTaskRightPredicateFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.MapIfAsync(FalsePredicate, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfValueTaskRightPredicateOnFailedSourceSkipsPredicateAndMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.MapIfAsync(TruePredicate, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }
}
