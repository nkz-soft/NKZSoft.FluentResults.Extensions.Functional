namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result> BindTryAsync(this Result result, Func<Task<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var output = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    public static async Task<Result<TValue>> BindTryAsync<TValue>(this Result result, Func<Task<Result<TValue>>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValue>(result.Errors);
        }

        var output = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    public static async Task<Result> BindTryAsync<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var output = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    public static async Task<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Task<Result<TValueOut>>> func,
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
