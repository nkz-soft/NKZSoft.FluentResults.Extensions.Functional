namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Combines multiple results into a single result by delegating to FluentResults Merge.
    /// </summary>
    /// <param name="results">Results to combine.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static Result Combine(params Result[] results)
    {
        ArgumentNullException.ThrowIfNull(results);

        foreach (var result in results)
        {
            ArgumentNullException.ThrowIfNull(result);
        }

        return Result.Merge(results);
    }

    /// <summary>
    /// Combines multiple value results into a single value result by delegating to FluentResults Merge.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">Results to combine.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static Result<IEnumerable<TValue>> Combine<TValue>(params Result<TValue>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);

        foreach (var result in results)
        {
            ArgumentNullException.ThrowIfNull(result);
        }

        return Result.Merge(results);
    }
}
