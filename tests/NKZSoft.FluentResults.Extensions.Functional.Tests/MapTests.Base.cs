namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class MapTestsBase : TestBase
{
    protected class TValueMapped
    {
        public static readonly TValueMapped Value = new();
    }

    protected TValueMapped MapFunc()
    {
        FuncExecuted = true;
        return TValueMapped.Value;
    }

    protected TValueMapped MapFunc(TValue value)
    {
        FuncExecuted = true;
        return TValueMapped.Value;
    }

    protected Task<TValueMapped> TaskMapFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(TValueMapped.Value);
    }

    protected Task<TValueMapped> TaskMapFuncAsync(TValue value)
    {
        FuncExecuted = true;
        return Task.FromResult(TValueMapped.Value);
    }

    protected ValueTask<TValueMapped> ValueTaskMapFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(TValueMapped.Value);
    }

    protected ValueTask<TValueMapped> ValueTaskMapFuncAsync(TValue value)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(TValueMapped.Value);
    }

    protected void AssertFailure(Result<TValueMapped> output)
    {
        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeFalse();
        output.Errors.Should().Contain(e => e.Message == ErrorMessage);
    }

    protected void AssertSuccess(Result<TValueMapped> output)
    {
        output.IsSuccess.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
        output.Value.Should().BeSameAs(TValueMapped.Value);
    }
}
