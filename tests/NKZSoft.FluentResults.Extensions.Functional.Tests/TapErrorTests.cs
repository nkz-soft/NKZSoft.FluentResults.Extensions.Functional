namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorTests : TapErrorTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void TapErrorExecutesActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = result.TapError(Action);

        AssertActionInvocation(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void TapErrorTExecutesActionOnFailureAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResultT() : FailedResultT();
        var output = result.TapError(Action);

        AssertActionInvocation(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void TapErrorExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = result.TapError(ErrorAction);

        AssertErrorInvocation(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void TapErrorTExecutesErrorActionForEachErrorAndReturnsSelf(bool isSuccess)
    {
        var result = isSuccess ? SucceededResultT() : FailedResultT();
        var output = result.TapError(ErrorAction);

        AssertErrorInvocation(result, output);
    }

    [Test]
    public void TapErrorThrowsWhenActionIsNull()
    {
        var action = () => Result.Fail(ErrorMessage).TapError((Action)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void TapErrorThrowsWhenErrorActionIsNull()
    {
        var action = () => Result.Fail(ErrorMessage).TapError((Action<IError>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
