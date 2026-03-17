namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the supplied condition is true and the result is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result TapErrorIf(this Result result, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        return condition ? result.TapError(action) : result;
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapErrorIf<TValue>(this Result<TValue> result, bool condition, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        return condition ? result.TapError(action) : result;
    }

    /// <summary>
    /// Executes an action for each error when the supplied condition is true and the result is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>The original result.</returns>
    public static Result TapErrorIf(this Result result, bool condition, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        return condition ? result.TapError(action) : result;
    }

    /// <summary>
    /// Executes an action for each error when the supplied condition is true and the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapErrorIf<TValue>(this Result<TValue> result, bool condition, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        return condition ? result.TapError(action) : result;
    }
}
