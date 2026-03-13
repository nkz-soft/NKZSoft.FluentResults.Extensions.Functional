namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps an awaited successful result value with an asynchronous valuetask function when the supplied condition is true.
    /// </summary>
    public static async ValueTask<Result<TValue>> MapIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        bool condition,
        Func<TValue, ValueTask<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps an awaited successful result value with an asynchronous task function when the supplied condition is true.
    /// </summary>
    public static async ValueTask<Result<TValue>> MapIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        bool condition,
        Func<TValue, Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapIfAsync(condition, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps an awaited successful result value with an asynchronous valuetask function when the supplied predicate evaluates to true.
    /// </summary>
    public static async ValueTask<Result<TValue>> MapIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<TValue, ValueTask<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapIfAsync(predicate, func).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps an awaited successful result value with an asynchronous task function when the supplied predicate evaluates to true.
    /// </summary>
    public static async ValueTask<Result<TValue>> MapIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<TValue, Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapIfAsync(predicate, func).ConfigureAwait(false);
    }
}
