namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        bool condition,
        Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(condition, check).ConfigureAwait(false);
    }

    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        bool condition,
        Func<TValue, Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(condition, check).ConfigureAwait(false);
    }

    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(predicate, check).ConfigureAwait(false);
    }

    public static async Task<Result<TValue>> CheckIfAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<TValue, Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(predicate, check).ConfigureAwait(false);
    }
}
