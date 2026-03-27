namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Traverses source values in parallel and combines value-task-based traversal results.
    /// </summary>
    /// <typeparam name="TValueIn">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The traversed value type.</typeparam>
    /// <param name="values">Source values to traverse.</param>
    /// <param name="traverse">ValueTask-based traversal delegate.</param>
    /// <returns>A combined value result preserving input ordering.</returns>
    public static ValueTask<Result<IEnumerable<TValueOut>>> TraverseParallelAsync<TValueIn, TValueOut>(
        this IEnumerable<TValueIn> values,
        Func<TValueIn, ValueTask<Result<TValueOut>>> traverse)
        => MapParallelAsync(values, traverse);

    /// <summary>
    /// Traverses source values in parallel and combines value-task-based traversal results.
    /// </summary>
    /// <typeparam name="TValueIn">The source value type.</typeparam>
    /// <typeparam name="TValueOut">The traversed value type.</typeparam>
    /// <param name="values">Source values to traverse.</param>
    /// <param name="traverse">ValueTask-based traversal delegate.</param>
    /// <param name="maxDegreeOfParallelism">Optional cap on concurrently scheduled operations.</param>
    /// <returns>A combined value result preserving input ordering.</returns>
    public static ValueTask<Result<IEnumerable<TValueOut>>> TraverseParallelAsync<TValueIn, TValueOut>(
        this IEnumerable<TValueIn> values,
        Func<TValueIn, ValueTask<Result<TValueOut>>> traverse,
        int? maxDegreeOfParallelism)
        => MapParallelAsync(values, traverse, maxDegreeOfParallelism);
}
