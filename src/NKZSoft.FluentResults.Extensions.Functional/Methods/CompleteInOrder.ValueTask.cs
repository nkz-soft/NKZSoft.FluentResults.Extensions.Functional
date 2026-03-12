namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously completes value-task-based results in input order into a single result.
    /// </summary>
    /// <param name="results">ValueTask results to complete.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static ValueTask<Result> CompleteInOrderAsync(params ValueTask<Result>[] results)
        => CombineInOrderAsync(results);

    /// <summary>
    /// Asynchronously completes value-task-based value results in input order into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">ValueTask results to complete.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static ValueTask<Result<IEnumerable<TValue>>> CompleteInOrderAsync<TValue>(params ValueTask<Result<TValue>>[] results)
        => CombineInOrderAsync(results);
}
