namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async ValueTask<Result> BindTryAsync(this Result result, Func<ValueTask<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var output = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    public static async ValueTask<Result<TValue>> BindTryAsync<TValue>(this Result result, Func<ValueTask<Result<TValue>>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValue>(result.Errors);
        }

        var output = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    public static async ValueTask<Result> BindTryAsync<TValue>(this Result<TValue> result, Func<TValue, ValueTask<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var output = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    public static async ValueTask<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, ValueTask<Result<TValueOut>>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValueOut>(result.Errors);
        }

        var output = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }
}
