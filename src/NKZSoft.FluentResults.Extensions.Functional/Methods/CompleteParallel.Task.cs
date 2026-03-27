namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously completes task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">Task results to complete.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static Task<Result> CompleteParallelAsync(params Task<Result>[] results)
        => CombineParallelAsync(results);

    /// <summary>
    /// Asynchronously completes task-based results in parallel into a single result.
    /// </summary>
    /// <param name="results">Task results to complete.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static Task<Result> CompleteParallelAsync(
        Task<Result>[] results,
        int? maxDegreeOfParallelism)
        => CombineParallelAsync(results, maxDegreeOfParallelism);

    /// <summary>
    /// Asynchronously completes task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">Task results to complete.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static Task<Result<IEnumerable<TValue>>> CompleteParallelAsync<TValue>(params Task<Result<TValue>>[] results)
        => CombineParallelAsync(results);

    /// <summary>
    /// Asynchronously completes task-based value results in parallel into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">Task results to complete.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static Task<Result<IEnumerable<TValue>>> CompleteParallelAsync<TValue>(
        Task<Result<TValue>>[] results,
        int? maxDegreeOfParallelism)
        => CombineParallelAsync(results, maxDegreeOfParallelism);
}
