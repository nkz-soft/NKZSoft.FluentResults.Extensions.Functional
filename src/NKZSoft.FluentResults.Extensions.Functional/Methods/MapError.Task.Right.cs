namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps all errors of a failed result with an asynchronous task mapper and returns successful results unchanged.
    /// </summary>
    public static async Task<Result> MapErrorAsync(this Result result, Func<IError, Task<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        return await result.InternalMapErrorAsync(error => new ValueTask<IError>(errorMapper(error))).ConfigureAwait(false);
    }

    /// <summary>
    /// Maps all errors of a failed result with an asynchronous task mapper and returns successful results unchanged.
    /// </summary>
    public static async Task<Result<TValue>> MapErrorAsync<TValue>(
        this Result<TValue> result,
        Func<IError, Task<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        return await result.InternalMapErrorAsync(error => new ValueTask<IError>(errorMapper(error))).ConfigureAwait(false);
    }
}
