namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Matches a Task of Result to either a success or failure action.
    /// </summary>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The action to execute if the Result is successful.</param>
    /// <param name="onFailure">The action to execute if the Result is failed.</param>
    /// <exception cref="ArgumentNullException">Thrown if onSuccess or onFailure is null.</exception>
    public static async ValueTask MatchAsync(this ValueTask<Result> resultTask, Action onSuccess, Action<IList<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        if (result.IsSuccess)
        {
            onSuccess();
        }
        else
        {
            onFailure(result.Errors);
        }
    }

    /// <summary>
    /// Matches a Task of Result to either a success or failure function.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the functions.</typeparam>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation. The task result contains the value returned by the executed function.</returns>
    public static async ValueTask<T> MatchAsync<T>(this ValueTask<Result> resultTask,
        Func<T> onSuccess,
        Func<IList<IError>, T> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        return result.IsSuccess
            ? onSuccess()
            : onFailure(result.Errors);
    }

    /// <summary>
    /// Matches a Task of Result to either a success or failure action.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The action to execute if the Result is successful.</param>
    /// <param name="onFailure">The action to execute if the Result is failed.</param>
    public static async ValueTask MatchAsync<TValue>(this ValueTask<Result<TValue>> resultTask,
        Action<TValue> onSuccess,
        Action<IList<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        if (result.IsSuccess)
        {
            onSuccess(result.Value);
        }
        else
        {
            onFailure(result.Errors);
        }
    }

    /// <summary>
    /// Matches a Task of Result to either a success or failure function.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the success or failure function.</typeparam>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation, returning the result of the success or failure function.</returns>
    public static async ValueTask<T> MatchAsync<T, TValue>(this ValueTask<Result<TValue>> resultTask,
        Func<TValue, T> onSuccess,
        Func<IList<IError>, T> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        var result = await resultTask.ConfigureAwait(false);

        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }
}
