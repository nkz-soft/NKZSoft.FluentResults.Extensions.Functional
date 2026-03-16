namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTestsTaskRight : TapIfTestsBase
{
    [Test]
    public async Task TapIfTaskRightConditionFalseSkipsAction()
    {
        var result = Result.Ok();

        var output = await result.TapIfAsync(false, TaskActionEmptyAsync);

        ActionExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task TapIfTaskRightPredicateTrueExecutesAction()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.TapIfAsync(TruePredicate, TaskActionTAsync);

        PredicateExecuted.Should().BeTrue();
        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }
}
