namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure,
    /// and returns the result of the executed function as a Task.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <param name="resultTask">The task that produces the Result.</param>
    /// <param name="func">The function to execute after the Result.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the result of the function.</returns>
    public static async Task<T> FinallyAsync<T>(this Task<Result> resultTask, Func<Result, Task<T>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await func(result).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure,
    /// and returns the result of the executed function as a Task.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <param name="resultTask">The task that produces the Result.</param>
    /// <param name="func">The function to execute after the Result.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the result of the function.</returns>
    public static async Task<T> FinallyAsync<T, TValue>(this Task<Result<TValue>> resultTask,
        Func<Result<TValue>, Task<T>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await func(result).ConfigureAwait(false);
    }
}
