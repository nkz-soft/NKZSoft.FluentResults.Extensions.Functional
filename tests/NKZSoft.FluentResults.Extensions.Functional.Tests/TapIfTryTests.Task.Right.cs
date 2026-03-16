namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTryTestsTaskRight : TapIfTryTestsBase
{
    [Test]
    public async Task TapIfTryAsyncExecutesTaskWhenResultIsSuccessful()
    {
        var result = Result.Ok();

        var output = await result.TapIfTryAsync(true, TaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: true);
    }

    [Test]
    public async Task TapIfTryAsyncPredicateFalseSkipsTask()
    {
        var result = Result.Ok();

        var output = await result.TapIfTryAsync(FalsePredicate, TaskActionEmptyAsync);

        PredicateExecuted.Should().BeTrue();
        AssertState(output, expectedActionExecuted: false, expectedSuccess: true);
    }
}
