namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result> OnFailureCompensateAsync(this ValueTask<Result> resultTask, Func<Result> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result> OnFailureCompensateAsync(
        this ValueTask<Result> resultTask,
        Func<IReadOnlyCollection<IError>, Result> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<Result<TValue>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, Result<TValue>> compensate)
        => resultTask.CompensateAsync(compensate);
}
