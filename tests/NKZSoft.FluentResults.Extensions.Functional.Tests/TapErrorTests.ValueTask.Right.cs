namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorTestsValueTaskRight : TapErrorTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskRightExecutesActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = await result.TapErrorAsync(ValueTaskActionAsync);

        AssertActionInvocation(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskRightExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = await result.TapErrorAsync(ValueTaskErrorActionAsync);

        AssertErrorInvocation(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskRightTExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResultT() : FailedResultT();
        var output = await result.TapErrorAsync(ValueTaskErrorActionAsync);

        AssertErrorInvocation(result, output);
    }
}
