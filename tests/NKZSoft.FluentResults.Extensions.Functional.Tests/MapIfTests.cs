namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapIfTests : MapIfTestsBase
{
    [Test]
    public void MapIfConditionFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.MapIf(false, MapFunc);

        AssertSkipped(result, output, predicateExecuted: false);
    }

    [Test]
    public void MapIfConditionTrueMapsValue()
    {
        var output = Result.Ok(TValue.Value).MapIf(true, MapFunc);

        AssertMapped(output);
    }

    [Test]
    public void MapIfConditionTrueOnFailedSourcePreservesFailure()
    {
        var output = Result.Fail<TValue>(ErrorMessage).MapIf(true, MapFunc);

        AssertFailurePreserved(output);
    }

    [Test]
    public void MapIfPredicateFalseReturnsOriginalResultAndSkipsMap()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.MapIf(FalsePredicate, MapFunc);

        AssertSkipped(result, output, predicateExecuted: true);
    }

    [Test]
    public void MapIfPredicateTrueMapsValue()
    {
        var output = Result.Ok(TValue.Value).MapIf(TruePredicate, MapFunc);

        PredicateExecuted.Should().BeTrue();
        AssertMapped(output);
    }

    [Test]
    public void MapIfPredicateOnFailedSourceSkipsPredicateAndMap()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = result.MapIf(TruePredicate, MapFunc);

        AssertSkipped(result, output, predicateExecuted: false);
    }
}
