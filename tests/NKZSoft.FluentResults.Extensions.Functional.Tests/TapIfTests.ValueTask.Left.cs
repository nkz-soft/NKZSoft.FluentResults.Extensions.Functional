namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTestsValueTaskLeft : TapIfTestsBase
{
    [Test]
    public async Task TapIfValueTaskLeftConditionTrueExecutesAction()
    {
        var result = new ValueTask<Result>(Result.Ok());

        var output = await result.TapIfAsync(true, ActionEmpty);

        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfValueTaskLeftPredicateFalseSkipsAction()
    {
        var result = new ValueTask<Result>(Result.Ok());

        var output = await result.TapIfAsync(FalsePredicate, ActionEmpty);

        PredicateExecuted.Should().BeTrue();
        ActionExecuted.Should().BeFalse();
        output.IsSuccess.Should().BeTrue();
    }
}
