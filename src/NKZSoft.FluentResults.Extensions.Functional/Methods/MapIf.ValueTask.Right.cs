namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps a successful result value with an asynchronous valuetask function when the supplied condition is true.
    /// </summary>
    public static ValueTask<Result<TValue>> MapIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<TValue, ValueTask<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.MapAsync(func) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Maps a successful result value with an asynchronous valuetask function when the supplied predicate evaluates to true.
    /// </summary>
    public static ValueTask<Result<TValue>> MapIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, ValueTask<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.MapAsync(func)
            : ValueTask.FromResult(result);
    }
}
