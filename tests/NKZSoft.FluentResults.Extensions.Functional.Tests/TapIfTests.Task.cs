namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTestsTask : TapIfTestsBase
{
    [Test]
    public async Task TapIfTaskConditionFalseSkipsAction()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();

        var output = await result.TapIfAsync(false, TaskActionEmptyAsync);

        ActionExecuted.Should().BeFalse();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfTaskConditionTrueExecutesAction()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();

        var output = await result.TapIfAsync(true, TaskActionEmptyAsync);

        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfTaskPredicateFalseSkipsAction()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage).AsTask();

        var output = await result.TapIfAsync(FalsePredicate, TaskActionEmptyAsync);

        PredicateExecuted.Should().BeTrue();
        ActionExecuted.Should().BeFalse();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfTaskPredicateOnFailedSourceSkipsPredicateAndAction()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage).AsTask();

        var output = await result.TapIfAsync(TruePredicate, TaskActionEmptyAsync);

        PredicateExecuted.Should().BeFalse();
        ActionExecuted.Should().BeFalse();
        output.IsFailed.Should().BeTrue();
    }

    [Test]
    public async Task TapIfTaskConditionTrueExecutesActionT()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value).AsTask();

        var output = await result.TapIfAsync(true, TaskActionTAsync);

        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }
}
