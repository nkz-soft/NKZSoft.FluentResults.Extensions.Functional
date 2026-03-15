namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async ValueTask<Result> BindTryAsync(this ValueTask<Result> resultTask, Func<Result> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindTry(func, errorHandler);
    }

    public static async ValueTask<Result<TValue>> BindTryAsync<TValue>(this ValueTask<Result> resultTask, Func<Result<TValue>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindTry(func, errorHandler);
    }

    public static async ValueTask<Result> BindTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, Result> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindTry(func, errorHandler);
    }

    public static async ValueTask<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, Result<TValueOut>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindTry(func, errorHandler);
    }
}
