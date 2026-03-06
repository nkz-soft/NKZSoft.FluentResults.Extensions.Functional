namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class SelectTestsBase : TestBase
{
    protected class TValueSelected
    {
        public static readonly TValueSelected Value = new();
    }

    protected TValueSelected SelectFunc()
    {
        FuncExecuted = true;
        return TValueSelected.Value;
    }

    protected TValueSelected SelectFunc(TValue value)
    {
        FuncExecuted = true;
        return TValueSelected.Value;
    }

    protected void AssertFailure(Result<TValueSelected> output)
    {
        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Errors.Should().Contain(e => e.Message == ErrorMessage);
    }

    protected void AssertSuccess(Result<TValueSelected> output)
    {
        output.IsSuccess.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
        output.Value.Should().BeSameAs(TValueSelected.Value);
    }
}
