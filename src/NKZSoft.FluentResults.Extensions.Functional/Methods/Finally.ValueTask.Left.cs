namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure,
    /// and returns the result of the executed function as a ValueTask.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <param name="resultTask">The ValueTask that produces the Result.</param>
    /// <param name="func">The function to execute after the Result.</param>
    /// <returns>A ValueTask representing the asynchronous operation. The ValueTask result contains the result of the function.</returns>
    public static async ValueTask<T> FinallyAsync<T>(this ValueTask<Result> resultTask, Func<Result, T> func)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.Finally(func);
    }

    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure,
    /// and returns the result of the executed function as a ValueTask.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <param name="resultTask">The ValueTask that returns a Result.</param>
    /// <param name="func">The function to execute after the Result.</param>
    /// <returns>A ValueTask representing the asynchronous operation. The ValueTask result contains the result of the function.</returns>
    public static async ValueTask<T> FinallyAsync<T, TValue>(this ValueTask<Result<TValue>> resultTask,
        Func<Result<TValue>, T> func)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.Finally(func);
    }
}
