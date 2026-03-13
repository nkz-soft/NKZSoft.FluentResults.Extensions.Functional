namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps all errors of a failed result with an asynchronous valuetask mapper and returns successful results unchanged.
    /// </summary>
    public static ValueTask<Result> MapErrorAsync(this Result result, Func<IError, ValueTask<IError>> errorMapper)
        => result.InternalMapErrorAsync(errorMapper);

    /// <summary>
    /// Maps all errors of a failed result with an asynchronous valuetask mapper and returns successful results unchanged.
    /// </summary>
    public static ValueTask<Result<TValue>> MapErrorAsync<TValue>(
        this Result<TValue> result,
        Func<IError, ValueTask<IError>> errorMapper)
        => result.InternalMapErrorAsync(errorMapper);
}
