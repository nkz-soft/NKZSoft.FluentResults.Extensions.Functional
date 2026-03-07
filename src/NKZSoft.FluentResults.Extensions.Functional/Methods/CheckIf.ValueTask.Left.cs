namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        bool condition,
        Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(condition, check);
    }

    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        bool condition,
        Func<TValue, Result> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(condition, check);
    }

    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(predicate, check);
    }

    public static async ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, bool> predicate,
        Func<TValue, Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        var result = await resultTask.ConfigureAwait(false);
        return result.CheckIf(predicate, check);
    }
}
