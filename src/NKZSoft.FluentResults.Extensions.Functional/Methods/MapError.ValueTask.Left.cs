namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps all errors of an awaited failed result and returns successful results unchanged.
    /// </summary>
    public static async ValueTask<Result> MapErrorAsync(this ValueTask<Result> resultTask, Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return result.MapError(errorMapper);
    }

    /// <summary>
    /// Maps all errors of an awaited failed result and returns successful results unchanged.
    /// </summary>
    public static async ValueTask<Result<TValue>> MapErrorAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return result.MapError(errorMapper);
    }
}
