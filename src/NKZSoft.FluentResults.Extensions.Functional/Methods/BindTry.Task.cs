namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result> BindTryAsync(this Task<Result> resultTask, Func<Task<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    public static async Task<Result<TValue>> BindTryAsync<TValue>(this Task<Result> resultTask, Func<Task<Result<TValue>>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    public static async Task<Result> BindTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    public static async Task<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, Task<Result<TValueOut>>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }
}
