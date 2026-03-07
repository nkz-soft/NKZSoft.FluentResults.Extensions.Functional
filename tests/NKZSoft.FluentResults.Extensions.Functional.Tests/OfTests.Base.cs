namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class OfTestsBase : TestBase
{
    protected const string ExceptionMessage = "Of Exception Message";

    protected static TValue SuccessFunc() => TValue.Value;

    protected static TValue FailFunc() => throw new InvalidOperationException(ExceptionMessage);

    protected static Task<TValue> SuccessTask() => Task.FromResult(TValue.Value);

    protected static Task<TValue> FailTask() => Task.FromException<TValue>(new InvalidOperationException(ExceptionMessage));

    protected static ValueTask<TValue> SuccessValueTask() => ValueTask.FromResult(TValue.Value);

    protected static ValueTask<TValue> FailValueTask() => ValueTask.FromException<TValue>(new InvalidOperationException(ExceptionMessage));
}
