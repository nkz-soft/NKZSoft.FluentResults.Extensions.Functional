namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(this Task<Result> resultTask, Func<Task<Result>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(
        this Task<Result> resultTask,
        Func<IReadOnlyCollection<IError>, Task<Result>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<Task<Result<TValue>>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, Task<Result<TValue>>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(this Task<Result> resultTask, Func<ValueTask<Result>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(
        this Task<Result> resultTask,
        Func<IReadOnlyCollection<IError>, ValueTask<Result>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<ValueTask<Result<TValue>>> compensate)
        => resultTask.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the awaited source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, ValueTask<Result<TValue>>> compensate)
        => resultTask.CompensateAsync(compensate);
}
