namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Gets the value of a successful result; otherwise returns a fallback value produced by an asynchronous function.
    /// </summary>
    public static async ValueTask<TValue> GetValueOrDefaultAsync<TValue>(
        this Result<TValue> result,
        Func<ValueTask<TValue>> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(defaultValue);
        return result.IsSuccess ? result.Value : await defaultValue().ConfigureAwait(false);
    }

    /// <summary>
    /// Projects the value of a successful result; otherwise returns the provided default value.
    /// </summary>
    public static async ValueTask<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, ValueTask<TValueOut>> selector,
        TValueOut defaultValue = default!)
    {
        ArgumentNullException.ThrowIfNull(selector);
        return result.IsSuccess ? await selector(result.Value).ConfigureAwait(false) : defaultValue;
    }

    /// <summary>
    /// Projects the value of a successful result; otherwise returns a fallback value produced by an asynchronous function.
    /// </summary>
    public static async ValueTask<TValueOut> GetValueOrDefaultAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, ValueTask<TValueOut>> selector,
        Func<ValueTask<TValueOut>> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(selector);
        ArgumentNullException.ThrowIfNull(defaultValue);

        return result.IsSuccess
            ? await selector(result.Value).ConfigureAwait(false)
            : await defaultValue().ConfigureAwait(false);
    }
}
