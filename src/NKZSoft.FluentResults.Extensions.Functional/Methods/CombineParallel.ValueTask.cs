namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously combines value-task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">ValueTask results to combine.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static ValueTask<Result> CombineParallelAsync(params ValueTask<Result>[] results)
        => InternalCombineParallelAsync(results, null, CancellationToken.None);

    /// <summary>
    /// Asynchronously combines value-task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">ValueTask results to combine.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static ValueTask<Result> CombineParallelAsync(
        ValueTask<Result>[] results,
        int? maxDegreeOfParallelism)
        => InternalCombineParallelAsync(results, maxDegreeOfParallelism, CancellationToken.None);

    /// <summary>
    /// Asynchronously combines value-task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">ValueTask results to combine.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static ValueTask<Result<IEnumerable<TValue>>> CombineParallelAsync<TValue>(params ValueTask<Result<TValue>>[] results)
        => InternalCombineParallelAsync(results, null, CancellationToken.None);

    /// <summary>
    /// Asynchronously combines value-task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">ValueTask results to combine.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static ValueTask<Result<IEnumerable<TValue>>> CombineParallelAsync<TValue>(
        ValueTask<Result<TValue>>[] results,
        int? maxDegreeOfParallelism)
        => InternalCombineParallelAsync(results, maxDegreeOfParallelism, CancellationToken.None);
}
