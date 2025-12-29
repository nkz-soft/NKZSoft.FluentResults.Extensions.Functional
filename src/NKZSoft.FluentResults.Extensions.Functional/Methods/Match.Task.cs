namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Matches a Task of Result to either a success or failure function.
    /// </summary>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public static async Task MatchAsync(this Task<Result> resultTask,
        Func<Task> onSuccess,
        Func<IReadOnlyList<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        if (result.IsSuccess)
        {
            await onSuccess().ConfigureAwait(false);
        }
        else
        {
            await onFailure(result.Errors).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Matches a Task of Result to either a success or failure function, returning a value of type T.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the functions.</typeparam>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful, returning a value of type T.</param>
    /// <param name="onFailure">The function to execute if the Result is failed, returning a value of type T.</param>
    /// <returns>A Task representing the asynchronous operation, returning a value of type T.</returns>
    public static async Task<T> MatchAsync<T>(this Task<Result> resultTask,
        Func<Task<T>> onSuccess,
        Func<IReadOnlyList<IError>, Task<T>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        return result.IsSuccess
            ? await onSuccess().ConfigureAwait(false)
            : await onFailure(result.Errors).ConfigureAwait(false);
    }

    /// <summary>
    /// Matches a Task of Result to either a success or failure function.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public static async Task MatchAsync<TValue>(this Task<Result<TValue>> resultTask,
        Func<Task<TValue>> onSuccess,
        Func<IReadOnlyList<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        if (result.IsSuccess)
        {
            await onSuccess().ConfigureAwait(false);
        }
        else
        {
            await onFailure(result.Errors).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Matches a Task of Result to either a success or failure function.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the functions.</typeparam>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation. The task result contains the value returned by the executed function.</returns>
    public static async Task<T> MatchAsync<T, TValue>(this Task<Result<TValue>> resultTask,
        Func<TValue, Task<T>> onSuccess,
        Func<IReadOnlyList<IError>, Task<T>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        return result.IsSuccess
            ? await onSuccess(result.Value).ConfigureAwait(false)
            : await onFailure(result.Errors).ConfigureAwait(false);
    }
}
