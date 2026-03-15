namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, bool condition, Func<Task<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(condition, func).ConfigureAwait(false);
    }

    public static async Task<Result<TValue>> BindIfAsync<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Task<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(condition, func).ConfigureAwait(false);
    }

    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<Task<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(predicate, func).ConfigureAwait(false);
    }

    public static async Task<Result<TValue>> BindIfAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, Task<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(predicate, func).ConfigureAwait(false);
    }
}
