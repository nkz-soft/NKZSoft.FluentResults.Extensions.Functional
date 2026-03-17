namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the result is failed.
    /// </summary>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="action">The action to execute if the result is failed.</param>
    /// <returns>The original result.</returns>
    public static Result TapError(this Result result, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            action();
        }
        return result;
    }

    /// <summary>
    /// Executes an action when the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="action">The action to execute if the result is failed.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapError<TValue>(this Result<TValue> result, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            action();
        }
        return result;
    }

    /// <summary>
    /// Executes an action for each error when the result is failed.
    /// </summary>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>The original result.</returns>
    public static Result TapError(this Result result, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            foreach (var error in result.Errors)
            {
                action(error);
            }
        }
        return result;
    }

    /// <summary>
    /// Executes an action for each error when the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="action">The action to execute for each error.</param>
    /// <returns>The original result.</returns>
    public static Result<TValue> TapError<TValue>(this Result<TValue> result, Action<IError> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            foreach (var error in result.Errors)
            {
                action(error);
            }
        }
        return result;
    }

    internal static async ValueTask<Result> InternalTapErrorAsync(this Result result, Func<IError, ValueTask> func)
    {
        if (result.IsFailed)
        {
            foreach (var error in result.Errors)
            {
                await func(error).ConfigureAwait(false);
            }
        }
        return result;
    }

    internal static async ValueTask<Result<TValue>> InternalTapErrorAsync<TValue>(this Result<TValue> result, Func<IError, ValueTask> func)
    {
        if (result.IsFailed)
        {
            foreach (var error in result.Errors)
            {
                await func(error).ConfigureAwait(false);
            }
        }
        return result;
    }
}
