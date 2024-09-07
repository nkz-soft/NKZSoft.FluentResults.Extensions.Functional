namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class TapTestsBase : TestBase
{
    private bool ActionExecuted { get;  set; }

    protected void ActionEmpty() => ActionExecuted = true;

    protected void ActionT(TValue value) => ActionEmpty();

    protected Task TaskActionEmptyAsync()
    {
        ActionExecuted = true;
        return Task.CompletedTask;
    }

    protected Task TaskActionTAsync(TValue value)
    {
        ActionExecuted = true;
        return Task.CompletedTask;
    }

    protected ValueTask ValueTaskActionEmptyAsync()
    {
        ActionExecuted = true;
        return ValueTask.CompletedTask;
    }

    protected ValueTask ValueTaskActionTAsync(TValue value)
    {
        ActionExecuted = true;
        return ValueTask.CompletedTask;
    }

    protected void AssertSuccess(Result<TValue> output, bool isSuccess)
    {
        ActionExecuted.Should().Be(isSuccess);
        output.IsSuccess.Should().Be(isSuccess);
    }

    protected void AssertSuccess(Result output, bool isSuccess)
    {
        ActionExecuted.Should().Be(isSuccess);
        output.IsSuccess.Should().Be(isSuccess);
    }
}
