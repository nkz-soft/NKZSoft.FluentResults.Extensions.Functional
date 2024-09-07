namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action if the result is successful.
    /// </summary>
    /// <param name="result">The result to check for success.</param>
    /// <param name="action">The action to execute if the result is successful.</param>
    /// <returns>The original result.</returns>
    public static Result Tap(this Result result, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsSuccess)
        {
            action();
        }
        return result;
    }

    /// <summary>
    /// Executes an action if the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The result to check for success.</param>
    /// <param name="action">The action to execute if the result is successful.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> Tap<TValue>(this Result<TValue> result, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsSuccess)
        {
            action();
        }
        return result;
    }

    /// <summary>
    /// Executes an action on the value of a successful result.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The result to check for success.</param>
    /// <param name="action">The action to execute on the value if the result is successful.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> Tap<TValue>(this Result<TValue> result, Action<TValue> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsSuccess)
        {
            action(result.Value);
        }
        return result;
    }
}
