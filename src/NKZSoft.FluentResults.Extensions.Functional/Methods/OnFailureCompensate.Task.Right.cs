namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(this Result result, Func<Task<Result>> compensate)
        => result.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result> OnFailureCompensateAsync(
        this Result result,
        Func<IReadOnlyCollection<IError>, Task<Result>> compensate)
        => result.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Result<TValue> result,
        Func<Task<Result<TValue>>> compensate)
        => result.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static Task<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Result<TValue> result,
        Func<IReadOnlyCollection<IError>, Task<Result<TValue>>> compensate)
        => result.CompensateAsync(compensate);
}
