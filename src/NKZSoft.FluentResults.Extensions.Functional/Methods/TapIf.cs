namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the supplied condition is true and the result is successful.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result TapIf(this Result result, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        return condition ? result.Tap(action) : result;
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        return condition ? result.Tap(action) : result;
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, bool condition, Action<TValue> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        return condition ? result.Tap(action) : result;
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result TapIf(this Result result, Func<bool> predicate, Action action)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        return result.IsSuccess && predicate()
            ? result.Tap(action)
            : result;
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Action action)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        return result.IsSuccess && predicate(result.Value)
            ? result.Tap(action)
            : result;
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Action<TValue> action)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        return result.IsSuccess && predicate(result.Value)
            ? result.Tap(action)
            : result;
    }
}
