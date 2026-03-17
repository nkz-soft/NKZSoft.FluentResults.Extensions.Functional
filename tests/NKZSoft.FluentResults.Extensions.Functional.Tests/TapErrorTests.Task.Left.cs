namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorTestsTaskLeft : TapErrorTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskLeftExecutesActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var result = Task.FromResult(isSuccess ? SucceededResult() : FailedResult());
        var output = await result.TapErrorAsync(Action);

        AssertActionInvocation(await result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskLeftExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = Task.FromResult(isSuccess ? SucceededResult() : FailedResult());
        var output = await result.TapErrorAsync(ErrorAction);

        AssertErrorInvocation(await result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskLeftTExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = Task.FromResult(isSuccess ? SucceededResultT() : FailedResultT());
        var output = await result.TapErrorAsync(ErrorAction);

        AssertErrorInvocation(await result, output);
    }
}
