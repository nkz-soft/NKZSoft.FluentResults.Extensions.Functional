namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class TapTryTestsBase : TestBase
{
    protected const string TryExceptionMessage = "TapTry Exception Message";
    protected const string CustomErrorMessage = "Custom TapTry Error Message";
    protected const string MetadataKey = "code";
    protected const string MetadataValue = "tap_try_error";

    private bool actionExecuted;

    protected void ActionEmpty() => actionExecuted = true;
    protected void ActionWithValue(TValue _) => actionExecuted = true;

    protected void ThrowAction()
    {
        actionExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected void ThrowActionWithValue(TValue _)
    {
        actionExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected Task TaskActionEmptyAsync()
    {
        actionExecuted = true;
        return Task.CompletedTask;
    }

    protected Task TaskActionWithValueAsync(TValue _)
    {
        actionExecuted = true;
        return Task.CompletedTask;
    }

    protected Task ThrowTaskActionAsync()
    {
        actionExecuted = true;
        return Task.FromException(new InvalidOperationException(TryExceptionMessage));
    }

    protected Task ThrowTaskActionWithValueAsync(TValue _)
    {
        actionExecuted = true;
        return Task.FromException(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask ValueTaskActionEmptyAsync()
    {
        actionExecuted = true;
        return ValueTask.CompletedTask;
    }

    protected ValueTask ValueTaskActionWithValueAsync(TValue _)
    {
        actionExecuted = true;
        return ValueTask.CompletedTask;
    }

    protected ValueTask ThrowValueTaskActionAsync()
    {
        actionExecuted = true;
        return ValueTask.FromException(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask ThrowValueTaskActionWithValueAsync(TValue _)
    {
        actionExecuted = true;
        return ValueTask.FromException(new InvalidOperationException(TryExceptionMessage));
    }

    protected static string CustomErrorHandler(Exception _) => CustomErrorMessage;
    protected static IError CustomIErrorHandler(Exception _) => new Error(CustomErrorMessage).WithMetadata(MetadataKey, MetadataValue);
    protected static IEnumerable<IError> CustomIErrorsHandler(Exception _) =>
        [new Error(CustomErrorMessage).WithMetadata(MetadataKey, MetadataValue)];

    protected void AssertState(Result output, bool expectedActionExecuted, bool expectedSuccess)
    {
        actionExecuted.Should().Be(expectedActionExecuted);
        output.IsSuccess.Should().Be(expectedSuccess);
    }

    protected void AssertState(Result<TValue> output, bool expectedActionExecuted, bool expectedSuccess)
    {
        actionExecuted.Should().Be(expectedActionExecuted);
        output.IsSuccess.Should().Be(expectedSuccess);
    }
}
