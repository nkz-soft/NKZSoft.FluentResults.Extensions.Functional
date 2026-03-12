namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously combines value-task-based results in input order into a single result.
    /// </summary>
    /// <param name="results">ValueTask results to combine.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static async ValueTask<Result> CombineInOrderAsync(params ValueTask<Result>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);

        var resolved = new Result[results.Length];
        for (var i = 0; i < results.Length; i++)
        {
            resolved[i] = await results[i].ConfigureAwait(false);
            ArgumentNullException.ThrowIfNull(resolved[i]);
        }

        return CombineInOrder(resolved);
    }

    /// <summary>
    /// Asynchronously combines value-task-based value results in input order into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">ValueTask results to combine.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static async ValueTask<Result<IEnumerable<TValue>>> CombineInOrderAsync<TValue>(params ValueTask<Result<TValue>>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);

        var resolved = new Result<TValue>[results.Length];
        for (var i = 0; i < results.Length; i++)
        {
            resolved[i] = await results[i].ConfigureAwait(false);
            ArgumentNullException.ThrowIfNull(resolved[i]);
        }

        return CombineInOrder(resolved);
    }
}
