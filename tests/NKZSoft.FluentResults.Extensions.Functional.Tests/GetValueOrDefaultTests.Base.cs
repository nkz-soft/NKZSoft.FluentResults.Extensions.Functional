namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class GetValueOrDefaultTestsBase : TestBase
{
    protected class TValueSelected
    {
        public static readonly TValueSelected Value = new();
    }

    protected bool DefaultExecuted { get; set; }
    protected bool SelectorExecuted { get; set; }

    protected TValue DefaultValueFactory()
    {
        DefaultExecuted = true;
        return TValue.Value;
    }

    protected Task<TValue> DefaultValueFactoryTask()
    {
        DefaultExecuted = true;
        return Task.FromResult(TValue.Value);
    }

    protected ValueTask<TValue> DefaultValueFactoryValueTask()
    {
        DefaultExecuted = true;
        return ValueTask.FromResult(TValue.Value);
    }

    protected TValueSelected SelectValue(TValue value)
    {
        SelectorExecuted = true;
        return TValueSelected.Value;
    }

    protected Task<TValueSelected> SelectValueTask(TValue value)
    {
        SelectorExecuted = true;
        return Task.FromResult(TValueSelected.Value);
    }

    protected ValueTask<TValueSelected> SelectValueValueTask(TValue value)
    {
        SelectorExecuted = true;
        return ValueTask.FromResult(TValueSelected.Value);
    }

    protected TValueSelected DefaultSelectedFactory()
    {
        DefaultExecuted = true;
        return TValueSelected.Value;
    }

    protected Task<TValueSelected> DefaultSelectedFactoryTask()
    {
        DefaultExecuted = true;
        return Task.FromResult(TValueSelected.Value);
    }

    protected ValueTask<TValueSelected> DefaultSelectedFactoryValueTask()
    {
        DefaultExecuted = true;
        return ValueTask.FromResult(TValueSelected.Value);
    }
}
