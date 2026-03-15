namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Task<Result<TValue?>> resultTask,
        Func<TValue, Task<Result<TValueOut?>>> func)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindOptionalAsync(func).ConfigureAwait(false);
    }

    public static async Task<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Task<Result<TValue?>> resultTask,
        Func<TValue, Task<Result<TValueOut?>>> func)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindOptionalAsync(func).ConfigureAwait(false);
    }
}
