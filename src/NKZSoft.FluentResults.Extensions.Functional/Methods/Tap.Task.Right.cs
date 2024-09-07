namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    ///  Executes a function if the result is successful.
    /// </summary>
    /// <param name="result">The result to check for success.</param>
    /// <param name="func">The function to execute if the result is successful.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async Task<Result> TapAsync(this Result result, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsSuccess)
        {
            await func().ConfigureAwait(false);
        }
        return result;
    }

    /// <summary>
    /// Executes a function if the result is successful.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to check for success.</param>
    /// <param name="func">The function to execute if the result is successful.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async Task<Result<T>> TapAsync<T>(this Result<T> result, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsSuccess)
        {
            await func().ConfigureAwait(false);
        }
        return result;
    }

    /// <summary>
    /// Executes a function if the result is successful.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to check for success.</param>
    /// <param name="func">The function to execute if the result is successful. The function takes the value of the result as a parameter and returns a Task.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async Task<Result<T>> TapAsync<T>(this Result<T> result, Func<T, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsSuccess)
        {
            await func(result.Value).ConfigureAwait(false);
        }
        return result;
    }
}
