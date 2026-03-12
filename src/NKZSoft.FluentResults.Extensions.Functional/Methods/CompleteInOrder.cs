namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Completes multiple results in order into a single result.
    /// </summary>
    /// <param name="results">Results to complete.</param>
    /// <returns>A merged result containing combined reasons.</returns>
    public static Result CompleteInOrder(params Result[] results)
        => CombineInOrder(results);

    /// <summary>
    /// Completes multiple value results in order into a single value result.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="results">Results to complete.</param>
    /// <returns>A merged value result containing combined reasons and values when successful.</returns>
    public static Result<IEnumerable<TValue>> CompleteInOrder<TValue>(params Result<TValue>[] results)
        => CombineInOrder(results);
}
