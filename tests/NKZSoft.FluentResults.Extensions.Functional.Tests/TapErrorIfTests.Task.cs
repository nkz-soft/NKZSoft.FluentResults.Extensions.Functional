namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorIfTestsTask : TapErrorIfTestsBase
{
    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfTaskExecutesValueTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorIfAsync(condition, ValueTaskActionAsync);

        AssertActionInvocation(source, output, condition);
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfTaskExecutesErrorValueTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorIfAsync(condition, ValueTaskErrorActionAsync);

        AssertErrorInvocation(source, output, condition);
    }
}
