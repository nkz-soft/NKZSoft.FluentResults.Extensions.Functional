namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Gets the value of a successful result; otherwise returns the provided default value.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="defaultValue">The fallback value for failed results.</param>
    /// <returns>The successful value or <paramref name="defaultValue"/> when failed.</returns>
    public static TValue GetValueOrDefault<TValue>(this Result<TValue> result, TValue defaultValue = default!)
        => result.IsSuccess ? result.Value : defaultValue;

    /// <summary>
    /// Gets the value of a successful result; otherwise returns a fallback value produced by a function.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="defaultValue">The fallback factory for failed results.</param>
    /// <returns>The successful value or the produced fallback when failed.</returns>
    public static TValue GetValueOrDefault<TValue>(this Result<TValue> result, Func<TValue> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(defaultValue);
        return result.IsSuccess ? result.Value : defaultValue();
    }

    /// <summary>
    /// Projects the value of a successful result; otherwise returns the provided default value.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The projected value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="selector">The projection to apply on success.</param>
    /// <param name="defaultValue">The fallback value for failed results.</param>
    /// <returns>The projected value or <paramref name="defaultValue"/> when failed.</returns>
    public static TValueOut GetValueOrDefault<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> selector,
        TValueOut defaultValue = default!)
    {
        ArgumentNullException.ThrowIfNull(selector);
        return result.IsSuccess ? selector(result.Value) : defaultValue;
    }

    /// <summary>
    /// Projects the value of a successful result; otherwise returns a fallback value produced by a function.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The projected value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="selector">The projection to apply on success.</param>
    /// <param name="defaultValue">The fallback factory for failed results.</param>
    /// <returns>The projected value or the produced fallback when failed.</returns>
    public static TValueOut GetValueOrDefault<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, TValueOut> selector,
        Func<TValueOut> defaultValue)
    {
        ArgumentNullException.ThrowIfNull(selector);
        ArgumentNullException.ThrowIfNull(defaultValue);
        return result.IsSuccess ? selector(result.Value) : defaultValue();
    }
}
