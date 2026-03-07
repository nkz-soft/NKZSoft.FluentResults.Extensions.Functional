namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<TValue, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }
}
