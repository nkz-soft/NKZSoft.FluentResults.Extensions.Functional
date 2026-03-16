namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTestsValueTask : TapIfTestsBase
{
    [Test]
    public async Task TapIfValueTaskConditionFalseSkipsAction()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage);

        var output = await result.TapIfAsync(false, ValueTaskActionEmptyAsync);

        ActionExecuted.Should().BeFalse();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfValueTaskConditionTrueExecutesAction()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage);

        var output = await result.TapIfAsync(true, ValueTaskActionEmptyAsync);

        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfValueTaskPredicateFalseSkipsAction()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage);

        var output = await result.TapIfAsync(FalsePredicate, TaskActionEmptyAsync);

        PredicateExecuted.Should().BeTrue();
        ActionExecuted.Should().BeFalse();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task TapIfValueTaskPredicateOnFailedSourceSkipsPredicateAndAction()
    {
        var result = ResultExtensions.OkIfAsync(false, ErrorMessage);

        var output = await result.TapIfAsync(TruePredicate, ValueTaskActionEmptyAsync);

        PredicateExecuted.Should().BeFalse();
        ActionExecuted.Should().BeFalse();
        output.IsFailed.Should().BeTrue();
    }

    [Test]
    public async Task TapIfValueTaskConditionTrueExecutesActionT()
    {
        var result = ResultExtensions.OkIfAsync(true, ErrorMessage, TValue.Value);

        var output = await result.TapIfAsync(true, ValueTaskActionTAsync);

        ActionExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }
}
