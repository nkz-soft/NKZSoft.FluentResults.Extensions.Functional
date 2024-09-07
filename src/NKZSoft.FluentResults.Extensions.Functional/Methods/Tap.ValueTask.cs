namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function if the result of a task is successful.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute if the result is successful.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result> TapAsync(this ValueTask<Result> resultTask, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await func().ConfigureAwait(false);
        }
        return result;
    }

    /// <summary>
    /// Executes a function if the result of a task is successful.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute if the result is successful.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await func().ConfigureAwait(false);
        }
        return result;
    }

    /// <summary>
    /// Executes a function if the result of a task is successful.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute if the result is successful. The function takes the value of the result as a parameter.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await func(result.Value).ConfigureAwait(false);
        }
        return result;
    }
}
