namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function if the result of a task is failed.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function if the result of a task is failed.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function if the result of a task is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result<TValue>> TapErrorAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function if the result of a task is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result<TValue>> TapErrorAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function for each error if the result of a task is failed.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute for each error if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function for each error if the result of a task is failed.
    /// </summary>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute for each error if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function for each error if the result of a task is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute for each error if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result<TValue>> TapErrorAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a function for each error if the result of a task is failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The task that produces the result.</param>
    /// <param name="func">The function to execute for each error if the result is failed.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the original result.</returns>
    public static async ValueTask<Result<TValue>> TapErrorAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.TapErrorAsync(func).ConfigureAwait(false);
    }
}
