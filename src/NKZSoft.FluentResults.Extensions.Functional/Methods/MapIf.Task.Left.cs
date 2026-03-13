namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps an awaited successful result value with a synchronous function when the supplied condition is true.
    /// </summary>
    public static async Task<Result<TValue>> MapIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        bool condition,
        Func<TValue, TValue> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.MapIf(condition, func);
    }

    /// <summary>
    /// Maps an awaited successful result value with a synchronous function when the supplied predicate evaluates to true.
    /// </summary>
    public static async Task<Result<TValue>> MapIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<TValue, TValue> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.MapIf(predicate, func);
    }
}
