namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapIfTryTestsValueTaskRight : TapIfTryTestsBase
{
    [Test]
    public async Task TapIfTryAsyncExecutesValueTaskWhenResultIsSuccessful()
    {
        var result = Result.Ok();

        var output = await result.TapIfTryAsync(true, ValueTaskActionEmptyAsync);

        AssertState(output, expectedActionExecuted: true, expectedSuccess: true);
    }

    [Test]
    public async Task TapIfTryAsyncPredicateFalseSkipsValueTask()
    {
        var result = Result.Ok();

        var output = await result.TapIfTryAsync(FalsePredicate, ValueTaskActionEmptyAsync);

        PredicateExecuted.Should().BeTrue();
        AssertState(output, expectedActionExecuted: false, expectedSuccess: true);
    }
}
