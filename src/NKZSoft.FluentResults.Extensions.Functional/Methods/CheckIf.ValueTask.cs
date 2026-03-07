namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        bool condition,
        Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(condition, check).ConfigureAwait(false);
    }

    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        bool condition,
        Func<TValue, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(condition, check).ConfigureAwait(false);
    }

    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(predicate, check).ConfigureAwait(false);
    }

    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<TValue, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CheckIfAsync(predicate, check).ConfigureAwait(false);
    }
}
