namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Matches a Result to either a success or failure action asynchronously.
    /// </summary>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The action to execute if the Result is successful.</param>
    /// <param name="onFailure">The action to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public static async Task MatchAsync(this Result result,
        Func<Task> onSuccess,
        Func<IReadOnlyList<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

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
    /// Matches a Result to either a success or failure function asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the functions.</typeparam>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation, returning the result of the executed function.</returns>
    public static async Task<T> MatchAsync<T>(this Result result,
        Func<Task<T>> onSuccess,
        Func<IReadOnlyList<IError>, Task<T>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        return result.IsSuccess
            ? await onSuccess().ConfigureAwait(false)
            : await onFailure(result.Errors).ConfigureAwait(false);
    }

    /// <summary>
    /// Matches a Result to either a success or failure action asynchronously.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The action to execute if the Result is successful.</param>
    /// <param name="onFailure">The action to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public static async Task MatchAsync<TValue>(this Result<TValue> result,
        Func<Task<TValue>> onSuccess,
        Func<IReadOnlyList<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

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
    /// Matches a Result to either a success or failure function asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the success or failure function.</typeparam>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>A Task representing the asynchronous operation, returning the result of the success or failure function.</returns>
    public static async Task<T> MatchAsync<T, TValue>(this Result<TValue> result,
        Func<TValue, Task<T>> onSuccess,
        Func<IReadOnlyList<IError>, Task<T>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        return result.IsSuccess
            ? await onSuccess(result.Value).ConfigureAwait(false)
            : await onFailure(result.Errors).ConfigureAwait(false);
    }
}
