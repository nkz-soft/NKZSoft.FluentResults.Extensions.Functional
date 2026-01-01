namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously maps a Result from a task using a function that returns a task.
    /// </summary>
    /// <typeparam name="TValue">The type of the value returned by the function.</typeparam>
    /// <param name="resultTask">The task that produces the Result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <returns>A task containing the mapped Result.</returns>
    public static async Task<Result<TValue>> MapAsync<TValue>(this Task<Result> resultTask, Func<Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously maps a Result from a task using a function that returns a task.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <typeparam name="TValueOut">The type of the value returned by the function.</typeparam>
    /// <param name="resultTask">The task that produces the Result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <returns>A task containing the mapped Result.</returns>
    public static async Task<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, Task<TValueOut>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }
}
