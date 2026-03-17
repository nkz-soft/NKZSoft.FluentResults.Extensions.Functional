namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function if the result is failed.
    /// </summary>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="func">The function to execute if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async Task<Result> TapErrorAsync(this Result result, Func<Task> func)
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
    public static async Task<Result<TValue>> TapErrorAsync<TValue>(this Result<TValue> result, Func<Task> func)
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
    public static Task<Result> TapErrorAsync(this Result result, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.InternalTapErrorAsync(error => new ValueTask(func(error))).AsTask();
    }

    /// <summary>
    /// Executes a function for each error if the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to check for failure.</param>
    /// <param name="func">The function to execute for each error if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static Task<Result<TValue>> TapErrorAsync<TValue>(this Result<TValue> result, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.InternalTapErrorAsync(error => new ValueTask(func(error))).AsTask();
    }
}
