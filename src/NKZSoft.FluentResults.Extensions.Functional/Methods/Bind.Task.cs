namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously binds the result of a task to a function that returns another task.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function that takes the result and returns a new task.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the result of the function.</returns>
    public static async Task<Result> BindAsync(this Task<Result> resultTask, Func<Task<Result>> func)
    {
        var result = await resultTask.ConfigureAwait(false);
        return await result.BindAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously binds the result of a task to a function that returns another task.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function that takes the value from the result and returns a new task.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the result of the function.</returns>
    public static async Task<Result<TValue>> BindAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result<TValue>>> func)
    {
        var result = await resultTask.ConfigureAwait(false);
        return await result.BindAsync(func).ConfigureAwait(false);
    }
}
