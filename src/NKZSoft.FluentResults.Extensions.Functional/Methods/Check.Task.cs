namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a check if the result from a task is successful.
    /// If the check fails, returns the failed Result.
    /// </summary>
    /// <param name="resultTask">The Task that produces the Result to check.</param>
    /// <param name="check">The check to execute.</param>
    /// <returns>A Task containing the original Result when successful, otherwise the failed check Result.</returns>
    public static async Task<Result> CheckAsync(this Task<Result> resultTask, Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckAsync(check).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a check if the result from a task is successful.
    /// If the check fails, returns a failed Result with the check errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="resultTask">The Task that produces the Result to check.</param>
    /// <param name="check">The check to execute.</param>
    /// <returns>A Task containing the original Result when successful, otherwise a failed Result with the check errors.</returns>
    public static async Task<Result<TValue>> CheckAsync<TValue>(this Task<Result<TValue>> resultTask, Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckAsync(check).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes a check if the result from a task is successful.
    /// If the check fails, returns a failed Result with the check errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="resultTask">The Task that produces the Result to check.</param>
    /// <param name="check">The check to execute using the Result value.</param>
    /// <returns>A Task containing the original Result when successful, otherwise a failed Result with the check errors.</returns>
    public static async Task<Result<TValue>> CheckAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckAsync(check).ConfigureAwait(false);
    }
}
