namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously completes task-based results in input order into a single result.
    /// </summary>
    /// <param name="results">Task results to complete.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static Task<Result> CompleteInOrderAsync(params Task<Result>[] results)
        => CombineInOrderAsync(results);

    /// <summary>
    /// Asynchronously completes task-based value results in input order into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">Task results to complete.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static Task<Result<IEnumerable<TValue>>> CompleteInOrderAsync<TValue>(params Task<Result<TValue>>[] results)
        => CombineInOrderAsync(results);
}
