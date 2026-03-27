namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously completes value-task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">ValueTask results to complete.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static ValueTask<Result> CompleteParallelAsync(params ValueTask<Result>[] results)
        => CombineParallelAsync(results);

    /// <summary>
    /// Asynchronously completes value-task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">ValueTask results to complete.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static ValueTask<Result> CompleteParallelAsync(
        ValueTask<Result>[] results,
        int? maxDegreeOfParallelism)
        => CombineParallelAsync(results, maxDegreeOfParallelism);

    /// <summary>
    /// Asynchronously completes value-task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">ValueTask results to complete.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static ValueTask<Result<IEnumerable<TValue>>> CompleteParallelAsync<TValue>(params ValueTask<Result<TValue>>[] results)
        => CombineParallelAsync(results);

    /// <summary>
    /// Asynchronously completes value-task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">ValueTask results to complete.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static ValueTask<Result<IEnumerable<TValue>>> CompleteParallelAsync<TValue>(
        ValueTask<Result<TValue>>[] results,
        int? maxDegreeOfParallelism)
        => CombineParallelAsync(results, maxDegreeOfParallelism);
}
