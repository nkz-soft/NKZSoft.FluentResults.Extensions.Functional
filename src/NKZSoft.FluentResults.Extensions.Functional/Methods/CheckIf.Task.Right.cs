namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static Task<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.CheckAsync(check) : Task.FromResult(result);
    }

    public static Task<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<TValue, Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.CheckAsync(check) : Task.FromResult(result);
    }

    public static Task<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.CheckAsync(check) : Task.FromResult(result);
    }

    public static Task<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.CheckAsync(check) : Task.FromResult(result);
    }
}
