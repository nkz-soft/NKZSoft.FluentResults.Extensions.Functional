namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorIfTestsTaskLeft : TapErrorIfTestsBase
{
    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfTaskLeftExecutesActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorIfAsync(condition, Action);

        AssertActionInvocation(source, output, condition);
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public async Task TapErrorIfTaskLeftExecutesErrorActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var source = isSuccess ? SucceededResult() : FailedResult();
        var output = await Task.FromResult(source).TapErrorIfAsync(condition, ErrorAction);

        AssertErrorInvocation(source, output, condition);
    }
}
