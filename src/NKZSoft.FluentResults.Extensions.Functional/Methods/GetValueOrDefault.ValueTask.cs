namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Gets the value of a successful result from a value task; otherwise returns a fallback value produced by an asynchronous function.
    /// </summary>
    public static async ValueTask<TValue> GetValueOrDefaultAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<ValueTask<TValue>> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(defaultValue);

        var result = await resultTask.ConfigureAwait(false);
        return await result.GetValueOrDefaultAsync(defaultValue).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets the value of a successful result from a value task; otherwise returns a fallback value produced by an asynchronous function.
    /// </summary>
    public static async ValueTask<TValue> GetValueOrDefaultAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<Task<TValue>> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(defaultValue);

        var result = await resultTask.ConfigureAwait(false);
        return await result.GetValueOrDefaultAsync(defaultValue).ConfigureAwait(false);
    }

    /// <summary>
    /// Projects the value of a successful result from a value task; otherwise returns the provided default value.
    /// </summary>
    public static async ValueTask<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, ValueTask<TValueOut>> selector,
        TValueOut defaultValue = default!)
    {
        ArgumentNullException.ThrowIfNull(selector);

        var result = await resultTask.ConfigureAwait(false);
        return await result.GetValueOrDefaultAsync(selector, defaultValue).ConfigureAwait(false);
    }

    /// <summary>
    /// Projects the value of a successful result from a value task; otherwise returns the provided default value.
    /// </summary>
    public static async ValueTask<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, Task<TValueOut>> selector,
        TValueOut defaultValue = default!)
    {
        ArgumentNullException.ThrowIfNull(selector);

        var result = await resultTask.ConfigureAwait(false);
        return await result.GetValueOrDefaultAsync(selector, defaultValue).ConfigureAwait(false);
    }

    /// <summary>
    /// Projects the value of a successful result from a value task; otherwise returns a fallback value produced by an asynchronous function.
    /// </summary>
    public static async ValueTask<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, ValueTask<TValueOut>> selector,
        Func<ValueTask<TValueOut>> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(selector);
        ArgumentNullException.ThrowIfNull(defaultValue);

        var result = await resultTask.ConfigureAwait(false);
        return await result.GetValueOrDefaultAsync(selector, defaultValue).ConfigureAwait(false);
    }

    /// <summary>
    /// Projects the value of a successful result from a value task; otherwise returns a fallback value produced by an asynchronous function.
    /// </summary>
    public static async ValueTask<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, Task<TValueOut>> selector,
        Func<Task<TValueOut>> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(selector);
        ArgumentNullException.ThrowIfNull(defaultValue);

        var result = await resultTask.ConfigureAwait(false);
        return await result.GetValueOrDefaultAsync(selector, defaultValue).ConfigureAwait(false);
    }
}
