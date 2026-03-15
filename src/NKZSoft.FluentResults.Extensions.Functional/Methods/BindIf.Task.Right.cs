namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static Task<Result> BindIfAsync(this Result result, bool condition, Func<Task<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }

    public static Task<Result<TValue>> BindIfAsync<TValue>(this Result<TValue> result, bool condition, Func<TValue, Task<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }

    public static Task<Result> BindIfAsync(this Result result, Func<bool> predicate, Func<Task<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate()
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }

    public static Task<Result<TValue>> BindIfAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, Task<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.BindAsync(func)
            : Task.FromResult(result);
    }
}
