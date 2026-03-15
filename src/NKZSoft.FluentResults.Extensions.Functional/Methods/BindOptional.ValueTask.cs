namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async ValueTask<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue?>> resultTask,
        Func<TValue, ValueTask<Result<TValueOut?>>> func)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindOptionalAsync(func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue?>> resultTask,
        Func<TValue, ValueTask<Result<TValueOut?>>> func)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindOptionalAsync(func).ConfigureAwait(false);
    }
}
