namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps a successful result value when the supplied condition is true.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether mapping runs.</param>
    /// <param name="func">Mapping function to execute when the condition is true.</param>
    /// <returns>The original result when the condition is false; otherwise the result of applying <see cref="Map{TValue,TValueOut}(Result{TValue},Func{TValue,TValueOut})"/>.</returns>
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, TValue> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.Map(func) : result;
    }

    /// <summary>
    /// Maps a successful result value when the supplied predicate evaluates to true.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether mapping runs.</param>
    /// <param name="func">Mapping function to execute when the predicate is true.</param>
    /// <returns>The original result when the source is failed or the predicate is false; otherwise the result of applying <see cref="Map{TValue,TValueOut}(Result{TValue},Func{TValue,TValueOut})"/>.</returns>
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, TValue> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.Map(func)
            : result;
    }
}
