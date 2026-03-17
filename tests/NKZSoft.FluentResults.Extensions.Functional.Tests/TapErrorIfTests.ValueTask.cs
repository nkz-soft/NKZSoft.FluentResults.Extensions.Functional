namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorIfTestsValueTask : TapErrorIfTestsBase
{
    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfValueTaskExecutesTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorIfAsync(condition, TaskActionAsync);

        AssertActionInvocation(source, output, condition);
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfValueTaskExecutesErrorTaskActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorIfAsync(condition, TaskErrorActionAsync);

        AssertErrorInvocation(source, output, condition);
    }
}
