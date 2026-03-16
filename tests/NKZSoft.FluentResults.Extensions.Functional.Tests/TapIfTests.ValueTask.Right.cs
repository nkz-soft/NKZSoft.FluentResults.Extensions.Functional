namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTestsValueTaskRight : TapIfTestsBase
{
    [Test]
    public async Task TapIfValueTaskRightConditionFalseSkipsAction()
    {
        var result = Result.Ok();

        var output = await result.TapIfAsync(false, ValueTaskActionEmptyAsync);

        ActionExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task TapIfValueTaskRightPredicateTrueExecutesAction()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.TapIfAsync(TruePredicate, ValueTaskActionTAsync);

        PredicateExecuted.Should().BeTrue();
        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }
}
