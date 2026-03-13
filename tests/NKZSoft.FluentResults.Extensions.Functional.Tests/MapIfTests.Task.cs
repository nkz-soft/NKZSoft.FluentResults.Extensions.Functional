namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapIfTestsTask : MapIfTestsBase
{
    [Test]
    public async Task MapIfTaskConditionFalseReturnsOriginalResultAndSkipsTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).MapIfAsync(false, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfTaskConditionTrueMapsValueWithTaskFunc()
    {
        var output = await Task.FromResult(Result.Ok(TValue.Value)).MapIfAsync(true, TaskMapFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfTaskPredicateFalseReturnsOriginalResultAndSkipsTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).MapIfAsync(FalsePredicate, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfTaskPredicateOnFailedSourceSkipsPredicateAndTaskMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await Task.FromResult(result).MapIfAsync(TruePredicate, TaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfTaskConditionFalseReturnsOriginalResultAndSkipsValueTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).MapIfAsync(false, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public async Task MapIfTaskConditionTrueMapsValueWithValueTaskFunc()
    {
        var output = await Task.FromResult(Result.Ok(TValue.Value)).MapIfAsync(true, ValueTaskMapFuncAsync);

        AssertMapped(output);
    }

    [Test]
    public async Task MapIfTaskPredicateFalseReturnsOriginalResultAndSkipsValueTaskMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).MapIfAsync(FalsePredicate, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public async Task MapIfTaskPredicateOnFailedSourceSkipsPredicateAndValueTaskMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await Task.FromResult(result).MapIfAsync(TruePredicate, ValueTaskMapFuncAsync);

        AssertSkipped(result, output, predicateExecuted: false);
    }
}
