namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps all errors of an awaited failed result with an asynchronous task mapper and returns successful results unchanged.
    /// </summary>
    public static async Task<Result> MapErrorAsync(this Task<Result> resultTask, Func<IError, Task<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapErrorAsync(errorMapper).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps all errors of an awaited failed result with an asynchronous valuetask mapper and returns successful results unchanged.
    /// </summary>
    public static async Task<Result> MapErrorAsync(
        this Task<Result> resultTask,
        Func<IError, ValueTask<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return await result.InternalMapErrorAsync(errorMapper).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps all errors of an awaited failed result with an asynchronous task mapper and returns successful results unchanged.
    /// </summary>
    public static async Task<Result<TValue>> MapErrorAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IError, Task<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapErrorAsync(errorMapper).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps all errors of an awaited failed result with an asynchronous valuetask mapper and returns successful results unchanged.
    /// </summary>
    public static async Task<Result<TValue>> MapErrorAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IError, ValueTask<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return await result.InternalMapErrorAsync(errorMapper).ConfigureAwait(false);
    }
}
