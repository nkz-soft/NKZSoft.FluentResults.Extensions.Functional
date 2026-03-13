namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapIfTestsTaskRight : MapIfTestsBase
{
    [Test]
    public async Task MapIfTaskRightConditionFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.MapIfAsync(false, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfTaskRightConditionTrueMapsValue()
    {
        var output = await Result.Ok(TValue.Value).MapIfAsync(true, TaskMapFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfTaskRightPredicateFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.MapIfAsync(FalsePredicate, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfTaskRightPredicateOnFailedSourceSkipsPredicateAndMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.MapIfAsync(TruePredicate, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }
}
