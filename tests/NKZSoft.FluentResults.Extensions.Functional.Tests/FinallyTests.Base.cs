namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class FinallyTestsBase : TestBase
{
    protected TValue TValueResultFunc(Result arg)
    {
        FuncExecuted = true;
        return TValue.Value;
    }

    protected TValue TValueResultTFunc(Result<TValue> arg)
    {
        FuncExecuted = true;
        return TValue.Value;
    }

    protected Task<TValue> TaskTValueResultFuncAsync(Result arg)
    {
        FuncExecuted = true;
        return Task.FromResult(TValue.Value);
    }

    protected Task<TValue> TaskTValueResultTFuncAsync(Result<TValue> arg)
    {
        FuncExecuted = true;
        return Task.FromResult(TValue.Value);
    }

    protected Task<TValue> TaskFuncResultTAsync(Result<TValue> result)
    {
        FuncExecuted = true;
        return Task.FromResult(TValue.Value);
    }

    protected ValueTask<TValue> ValueTaskTValueResultFuncAsync(Result arg)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(TValue.Value);
    }

    protected ValueTask<TValue> ValueTaskTValueResultTFuncAsync(Result<TValue> arg)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(TValue.Value);
    }

    protected void AssertCalled(Result result, TValue output)
    {
        AssertCalled(output);
    }

    protected void AssertCalled(Result<TValue> result, TValue output)
    {
        AssertCalled(output);
    }

    protected void AssertCalled(TValue output) {
        FuncExecuted.Should().BeTrue();
        output.Should().Be(TValue.Value);
    }
}
