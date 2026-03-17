namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function if the result is failed.
    /// </summary>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="func">The function to execute if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result> TapErrorAsync(this Result result, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            await func().ConfigureAwait(false);
        }
        return result;
    }

    /// <summary>
    /// Executes a function if the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="func">The function to execute if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result<TValue>> TapErrorAsync<TValue>(this Result<TValue> result, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            await func().ConfigureAwait(false);
        }
        return result;
    }

    /// <summary>
    /// Executes a function for each error if the result is failed.
    /// </summary>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="func">The function to execute for each error if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static ValueTask<Result> TapErrorAsync(this Result result, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.InternalTapErrorAsync(func);
    }

    /// <summary>
    /// Executes a function for each error if the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="func">The function to execute for each error if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static ValueTask<Result<TValue>> TapErrorAsync<TValue>(this Result<TValue> result, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.InternalTapErrorAsync(func);
    }
}
