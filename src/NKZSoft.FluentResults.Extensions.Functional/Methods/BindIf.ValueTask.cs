namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async ValueTask<Result> BindIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(condition, func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<TValue>> BindIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, bool condition, Func<TValue, ValueTask<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(condition, func).ConfigureAwait(false);
    }

    public static async ValueTask<Result> BindIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask<Result>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(predicate, func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<TValue>> BindIfAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, bool> predicate, Func<TValue, ValueTask<Result<TValue>>> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindIfAsync(predicate, func).ConfigureAwait(false);
    }
}
