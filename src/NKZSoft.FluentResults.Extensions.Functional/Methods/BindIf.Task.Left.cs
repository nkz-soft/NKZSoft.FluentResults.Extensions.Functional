namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, bool condition, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(condition, func);
    }

    public static async Task<Result<TValue>> BindIfAsync<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(condition, func);
    }

    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<Result> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(predicate, func);
    }

    public static async Task<Result<TValue>> BindIfAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, Result<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindIf(predicate, func);
    }
}
