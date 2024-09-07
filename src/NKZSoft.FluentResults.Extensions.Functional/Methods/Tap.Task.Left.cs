namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action if the result of the task is successful.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="action">The action to execute if the result is successful.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async Task<Result> TapAsync(this Task<Result> resultTask, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            action();
        }
        return result;
    }

    /// <summary>
    /// Executes an action if the result of the task is successful.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the Result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="action">The action to execute if the result is successful.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            action();
        }
        return result;
    }

    /// <summary>
    /// Executes an action if the result of the task is successful.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the Result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="action">The action to execute on the value if the result is successful.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            action(result.Value);
        }
        return result;
    }
}
