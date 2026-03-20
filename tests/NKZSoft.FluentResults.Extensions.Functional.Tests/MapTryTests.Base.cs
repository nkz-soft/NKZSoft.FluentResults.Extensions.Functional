namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class MapTryTestsBase : TestBase
{
    protected const string TryExceptionMessage = "MapTry Exception Message";
    protected const string CustomErrorMessage = "Custom MapTry Error Message";
    protected const string MetadataKey = "code";
    protected const string MetadataValue = "map_try_error";

    protected class TValueMapped
    {
        public static readonly TValueMapped Value = new();
    }

    protected TValueMapped MapFunc()
    {
        FuncExecuted = true;
        return TValueMapped.Value;
    }

    protected TValueMapped MapFunc(TValue _)
    {
        FuncExecuted = true;
        return TValueMapped.Value;
    }

    protected TValueMapped ThrowMapFunc()
    {
        FuncExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected TValueMapped ThrowMapFunc(TValue _)
    {
        FuncExecuted = true;
        throw new InvalidOperationException(TryExceptionMessage);
    }

    protected Task<TValueMapped> TaskMapFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromResult(TValueMapped.Value);
    }

    protected Task<TValueMapped> TaskMapFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return Task.FromResult(TValueMapped.Value);
    }

    protected Task<TValueMapped> ThrowTaskMapFuncAsync()
    {
        FuncExecuted = true;
        return Task.FromException<TValueMapped>(new InvalidOperationException(TryExceptionMessage));
    }

    protected Task<TValueMapped> ThrowTaskMapFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return Task.FromException<TValueMapped>(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask<TValueMapped> ValueTaskMapFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromResult(TValueMapped.Value);
    }

    protected ValueTask<TValueMapped> ValueTaskMapFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(TValueMapped.Value);
    }

    protected ValueTask<TValueMapped> ThrowValueTaskMapFuncAsync()
    {
        FuncExecuted = true;
        return ValueTask.FromException<TValueMapped>(new InvalidOperationException(TryExceptionMessage));
    }

    protected ValueTask<TValueMapped> ThrowValueTaskMapFuncAsync(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromException<TValueMapped>(new InvalidOperationException(TryExceptionMessage));
    }

    protected static string CustomErrorHandler(Exception _) => CustomErrorMessage;
    protected static IError CustomIErrorHandler(Exception _) => new Error(CustomErrorMessage).WithMetadata(MetadataKey, MetadataValue);
    protected static IEnumerable<IError> CustomIErrorsHandler(Exception _) =>
        [new Error(CustomErrorMessage).WithMetadata(MetadataKey, MetadataValue)];

    protected void AssertSuccess(Result<TValueMapped> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValueMapped.Value);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertSourceFailure(Result<TValueMapped> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == ErrorMessage);
        FuncExecuted.Should().BeFalse();
    }

    protected void AssertDefaultFailure(Result<TValueMapped> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertCustomFailure(Result<TValueMapped> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
        FuncExecuted.Should().BeTrue();
    }
}
