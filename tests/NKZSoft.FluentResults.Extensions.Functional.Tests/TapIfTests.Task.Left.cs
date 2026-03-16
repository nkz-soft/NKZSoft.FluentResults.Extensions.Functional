namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTestsTaskLeft : TapIfTestsBase
{
    [Test]
    public async Task TapIfTaskLeftConditionTrueExecutesAction()
    {
        var result = Task.FromResult(Result.Ok());

        var output = await result.TapIfAsync(true, ActionEmpty);

        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfTaskLeftPredicateFalseSkipsAction()
    {
        var result = Task.FromResult(Result.Ok());

        var output = await result.TapIfAsync(FalsePredicate, ActionEmpty);

        PredicateExecuted.Should().BeTrue();
        ActionExecuted.Should().BeFalse();
        output.IsSuccess.Should().BeTrue();
    }
}
