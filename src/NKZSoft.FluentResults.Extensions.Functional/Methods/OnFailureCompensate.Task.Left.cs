namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(this Task<Result> resultTask, Func<Result> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(
        this Task<Result> resultTask,
        Func<IReadOnlyCollection<IError>, Result> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<Result<TValue>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, Result<TValue>> compensate)
        => resultTask.CompensateAsync(compensate);
}
