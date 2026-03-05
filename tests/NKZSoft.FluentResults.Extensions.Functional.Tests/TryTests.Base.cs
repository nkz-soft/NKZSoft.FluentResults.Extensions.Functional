namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class TryTestsBase : TestBase
{
    protected const string TryExceptionMessage = "Try Exception Message";
    protected const string CustomErrorMessage = "Custom Try Error Message";

    protected static void SuccessAction()
    {
    }

    protected static void FailAction() => throw new InvalidOperationException(TryExceptionMessage);

    protected static TValue SuccessFunc() => TValue.Value;

    protected static TValue FailFunc() => throw new InvalidOperationException(TryExceptionMessage);

    protected static Task SuccessTaskAction() => Task.CompletedTask;

    protected static Task FailTaskAction() => Task.FromException(new InvalidOperationException(TryExceptionMessage));

    protected static Task<TValue> SuccessTaskFunc() => Task.FromResult(TValue.Value);

    protected static Task<TValue> FailTaskFunc() => Task.FromException<TValue>(new InvalidOperationException(TryExceptionMessage));

    protected static ValueTask SuccessValueTaskAction() => ValueTask.CompletedTask;

    protected static ValueTask FailValueTaskAction() => ValueTask.FromException(new InvalidOperationException(TryExceptionMessage));

    protected static ValueTask<TValue> SuccessValueTaskFunc() => ValueTask.FromResult(TValue.Value);

    protected static ValueTask<TValue> FailValueTaskFunc() => ValueTask.FromException<TValue>(new InvalidOperationException(TryExceptionMessage));

    protected static string CustomErrorHandler(Exception _) => CustomErrorMessage;
}
