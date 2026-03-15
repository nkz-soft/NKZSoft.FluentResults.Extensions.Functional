namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static ValueTask<Result> BindIfAsync(this Result result, bool condition, Func<ValueTask<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition
            ? result.BindAsync(func)
            : ValueTask.FromResult(result);
    }

    public static ValueTask<Result<TValue>> BindIfAsync<TValue>(this Result<TValue> result, bool condition, Func<TValue, ValueTask<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition
            ? result.BindAsync(func)
            : ValueTask.FromResult(result);
    }

    public static ValueTask<Result> BindIfAsync(this Result result, Func<bool> predicate, Func<ValueTask<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate()
            ? result.BindAsync(func)
            : ValueTask.FromResult(result);
    }

    public static ValueTask<Result<TValue>> BindIfAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, ValueTask<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.BindAsync(func)
            : ValueTask.FromResult(result);
    }
}
