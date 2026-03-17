namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorTestsTaskRight : TapErrorTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskRightExecutesActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = await result.TapErrorAsync(TaskActionAsync);

        AssertActionInvocation(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskRightExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = await result.TapErrorAsync(TaskErrorActionAsync);

        AssertErrorInvocation(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task TapErrorTaskRightTExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResultT() : FailedResultT();
        var output = await result.TapErrorAsync(TaskErrorActionAsync);

        AssertErrorInvocation(result, output);
    }

    [Test]
    public async Task TapErrorTaskRightThrowsWhenFuncIsNull()
    {
        var action = () => Result.Fail(ErrorMessage).TapErrorAsync((Func<Task>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task TapErrorTaskRightThrowsWhenErrorFuncIsNull()
    {
        var action = () => Result.Fail(ErrorMessage).TapErrorAsync((Func<IError, Task>)null!);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
