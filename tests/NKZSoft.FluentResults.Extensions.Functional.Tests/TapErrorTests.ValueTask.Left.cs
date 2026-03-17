namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorTestsValueTaskLeft : TapErrorTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskLeftExecutesActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorAsync(Action);

        AssertActionInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskLeftExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorAsync(ErrorAction);

        AssertErrorInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskLeftTExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResultT() : FailedResultT();
        var output = await ValueTask.FromResult(source).TapErrorAsync(ErrorAction);

        AssertErrorInvocation(source, output);
    }
}
