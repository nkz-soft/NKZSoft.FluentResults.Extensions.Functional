namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapIfTestsValueTask : MapIfTestsBase
{
    [Test]
    public async Task MapIfValueTaskConditionFalseReturnsOriginalResultAndSkipsValueTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(false, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfValueTaskConditionTrueMapsValueWithValueTaskFunc()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Ok(TValue.Value)).MapIfAsync(true, ValueTaskMapFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfValueTaskPredicateFalseReturnsOriginalResultAndSkipsValueTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(FalsePredicate, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfValueTaskPredicateOnFailedSourceSkipsPredicateAndValueTaskMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(TruePredicate, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfValueTaskConditionFalseReturnsOriginalResultAndSkipsTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(false, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfValueTaskConditionTrueMapsValueWithTaskFunc()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Ok(TValue.Value)).MapIfAsync(true, TaskMapFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfValueTaskPredicateFalseReturnsOriginalResultAndSkipsTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(FalsePredicate, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfValueTaskPredicateOnFailedSourceSkipsPredicateAndTaskMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).MapIfAsync(TruePredicate, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }
}
