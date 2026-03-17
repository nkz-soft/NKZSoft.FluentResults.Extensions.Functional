namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorIfTestsTaskRight : TapErrorIfTestsBase
{
    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfTaskRightExecutesTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await source.TapErrorIfAsync(condition, TaskActionAsync);

        AssertActionInvocation(source, output, condition);
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfTaskRightExecutesErrorTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await source.TapErrorIfAsync(condition, TaskErrorActionAsync);

        AssertErrorInvocation(source, output, condition);
    }
}
