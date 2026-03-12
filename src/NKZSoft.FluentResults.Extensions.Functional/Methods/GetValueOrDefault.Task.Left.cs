namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Gets the value of a successful result from a task; otherwise returns the provided default value.
    /// </summary>
    public static async Task<TValue> GetValueOrDefaultAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        TValue defaultValue = default!)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.GetValueOrDefault(defaultValue);
    }

    /// <summary>
    /// Gets the value of a successful result from a task; otherwise returns a fallback value produced by a function.
    /// </summary>
    public static async Task<TValue> GetValueOrDefaultAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<TValue> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(defaultValue);

        var result = await resultTask.ConfigureAwait(false);
        return result.GetValueOrDefault(defaultValue);
    }

    /// <summary>
    /// Projects the value of a successful result from a task; otherwise returns the provided default value.
    /// </summary>
    public static async Task<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, TValueOut> selector,
        TValueOut defaultValue = default!)
    {
        ArgumentNullException.ThrowIfNull(selector);

        var result = await resultTask.ConfigureAwait(false);
        return result.GetValueOrDefault(selector, defaultValue);
    }

    /// <summary>
    /// Projects the value of a successful result from a task; otherwise returns a fallback value produced by a function.
    /// </summary>
    public static async Task<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, TValueOut> selector,
        Func<TValueOut> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(selector);
        ArgumentNullException.ThrowIfNull(defaultValue);

        var result = await resultTask.ConfigureAwait(false);
        return result.GetValueOrDefault(selector, defaultValue);
    }
}
