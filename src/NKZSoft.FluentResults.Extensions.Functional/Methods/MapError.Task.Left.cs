namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps all errors of an awaited failed result and returns successful results unchanged.
    /// </summary>
    public static async Task<Result> MapErrorAsync(this Task<Result> resultTask, Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return result.MapError(errorMapper);
    }

    /// <summary>
    /// Maps all errors of an awaited failed result and returns successful results unchanged.
    /// </summary>
    public static async Task<Result<TValue>> MapErrorAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        var result = await resultTask.ConfigureAwait(false);
        return result.MapError(errorMapper);
    }
}
