namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Awaits the source result and chains the next asynchronous operation only when it succeeds.
    /// </summary>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The asynchronous operation to run when the awaited result is successful.</param>
    /// <returns>A value task that returns the next result, or the original failure from the awaited result.</returns>
    public static async ValueTask<Result> BindAsync(this ValueTask<Result> resultTask, Func<ValueTask<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Awaits the source result and chains the next asynchronous operation only when it succeeds.
    /// </summary>
    /// <typeparam name="TValue">The type carried by the awaited result.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The asynchronous operation to run with the successful source value.</param>
    /// <returns>A value task that returns the next result, or the original failure from the awaited result.</returns>
    public static async ValueTask<Result<TValue>> BindAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, ValueTask<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindAsync(func).ConfigureAwait(false);
    }
}
