namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class TapErrorIfTests : TapErrorIfTestsBase
{
    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public void TapErrorIfExecutesActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = result.TapErrorIf(condition, Action);

        AssertActionInvocation(result, output, condition);
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public void TapErrorIfExecutesErrorActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var result = isSuccess ? SucceededResult() : FailedResult();
        var output = result.TapErrorIf(condition, ErrorAction);

        AssertErrorInvocation(result, output, condition);
    }

    [Test]
    [Arguments(true, true)]
    [Arguments(true, false)]
    [Arguments(false, true)]
    [Arguments(false, false)]
    public void TapErrorIfTExecutesErrorActionConditionallyAndReturnsSelf(bool isSuccess, bool condition)
    {
        var result = isSuccess ? SucceededResultT() : FailedResultT();
        var output = result.TapErrorIf(condition, ErrorAction);

        AssertErrorInvocation(result, output, condition);
    }

    [Test]
    public void TapErrorIfThrowsWhenActionIsNull()
    {
        var action = () => Result.Fail(ErrorMessage).TapErrorIf(true, (Action)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void TapErrorIfThrowsWhenErrorActionIsNull()
    {
        var action = () => Result.Fail(ErrorMessage).TapErrorIf(true, (Action<IError>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
