namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously combines task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">Task results to combine.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static Task<Result> CombineParallelAsync(params Task<Result>[] results)
        => InternalCombineParallelAsync(results, null, CancellationToken.None);

    /// <summary>
    /// Asynchronously combines task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">Task results to combine.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static Task<Result> CombineParallelAsync(
        Task<Result>[] results,
        int? maxDegreeOfParallelism)
        => InternalCombineParallelAsync(results, maxDegreeOfParallelism, CancellationToken.None);

    /// <summary>
    /// Asynchronously combines task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">Task results to combine.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static Task<Result<IEnumerable<TValue>>> CombineParallelAsync<TValue>(params Task<Result<TValue>>[] results)
        => InternalCombineParallelAsync(results, null, CancellationToken.None);

    /// <summary>
    /// Asynchronously combines task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">Task results to combine.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static Task<Result<IEnumerable<TValue>>> CombineParallelAsync<TValue>(
        Task<Result<TValue>>[] results,
        int? maxDegreeOfParallelism)
        => InternalCombineParallelAsync(results, maxDegreeOfParallelism, CancellationToken.None);
}
