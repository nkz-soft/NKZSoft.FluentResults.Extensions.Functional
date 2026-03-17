namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorTestsTask : TapErrorTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskExecutesTaskActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorAsync(TaskActionAsync);

        AssertActionInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskExecutesValueTaskActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorAsync(ValueTaskActionAsync);

        AssertActionInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskExecutesErrorTaskActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorAsync(TaskErrorActionAsync);

        AssertErrorInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskExecutesErrorValueTaskActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorAsync(ValueTaskErrorActionAsync);

        AssertErrorInvocation(source, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskTExecutesErrorTaskActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var source = isSuccess ? SucceededResultT() : FailedResultT();
        var output = await Task.FromResult(source).TapErrorAsync(TaskErrorActionAsync);

        AssertErrorInvocation(source, output);
    }
}
