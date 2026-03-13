namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps a successful result value with an asynchronous task function when the supplied condition is true.
    /// </summary>
    public static Task<Result<TValue>> MapIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<TValue, Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.MapAsync(func) : Task.FromResult(result);
    }

    /// <summary>
    /// Maps a successful result value with an asynchronous task function when the supplied predicate evaluates to true.
    /// </summary>
    public static Task<Result<TValue>> MapIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.MapAsync(func)
            : Task.FromResult(result);
    }
}
