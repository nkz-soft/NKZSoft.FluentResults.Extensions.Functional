namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorTestsValueTask : TapErrorTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskExecutesValueTaskActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorAsync(ValueTaskActionAsync);

        AssertActionInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskExecutesTaskActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorAsync(TaskActionAsync);

        AssertActionInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskExecutesErrorValueTaskActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorAsync(ValueTaskErrorActionAsync);

        AssertErrorInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskExecutesErrorTaskActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await ValueTask.FromResult(source).TapErrorAsync(TaskErrorActionAsync);

        AssertErrorInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorValueTaskTExecutesErrorValueTaskActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResultT() : FailedResultT();
        var output = await ValueTask.FromResult(source).TapErrorAsync(ValueTaskErrorActionAsync);

        AssertErrorInvocation(source, output);
    }
}
