namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps source values to result values in parallel using task-based delegates.
    /// </summary>
    /// <typeparam name="TValueIn">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The mapped value type.</typeparam>
    /// <param name="values">Source values to map.</param>
    /// <param name="map">Task-based mapper that returns a result per value.</param>
    /// <returns>A combined value result preserving input ordering.</returns>
    public static Task<Result<IEnumerable<TValueOut>>> MapParallelAsync<TValueIn, TValueOut>(
        this IEnumerable<TValueIn> values,
        Func<TValueIn, Task<Result<TValueOut>>> map)
        => InternalMapParallelAsync(values, map, null, CancellationToken.None);

    /// <summary>
    /// Maps source values to result values in parallel using task-based delegates.
    /// </summary>
    /// <typeparam name="TValueIn">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The mapped value type.</typeparam>
    /// <param name="values">Source values to map.</param>
    /// <param name="map">Task-based mapper that returns a result per value.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A combined value result preserving input ordering.</returns>
    public static Task<Result<IEnumerable<TValueOut>>> MapParallelAsync<TValueIn, TValueOut>(
        this IEnumerable<TValueIn> values,
        Func<TValueIn, Task<Result<TValueOut>>> map,
        int? maxDegreeOfParallelism)
        => InternalMapParallelAsync(values, map, maxDegreeOfParallelism, CancellationToken.None);
}
