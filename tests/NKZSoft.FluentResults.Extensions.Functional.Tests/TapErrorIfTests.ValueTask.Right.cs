namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorIfTestsValueTaskRight : TapErrorIfTestsBase
{
    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfValueTaskRightExecutesValueTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await source.TapErrorIfAsync(condition, ValueTaskActionAsync);

        AssertActionInvocation(source, output, condition);
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfValueTaskRightExecutesErrorValueTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await source.TapErrorIfAsync(condition, ValueTaskErrorActionAsync);

        AssertErrorInvocation(source, output, condition);
    }
}
