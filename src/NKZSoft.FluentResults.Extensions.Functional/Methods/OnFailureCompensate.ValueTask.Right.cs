namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result> OnFailureCompensateAsync(this Result result, Func<ValueTask<Result>> compensate)
        => result.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result> OnFailureCompensateAsync(
        this Result result,
        Func<IReadOnlyCollection<IError>, ValueTask<Result>> compensate)
        => result.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Result<TValue> result,
        Func<ValueTask<Result<TValue>>> compensate)
        => result.CompensateAsync(compensate);

    /// <summary>
    /// Executes asynchronous fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    public static ValueTask<Result<TValue>> OnFailureCompensateAsync<TValue>(
        this Result<TValue> result,
        Func<IReadOnlyCollection<IError>, ValueTask<Result<TValue>>> compensate)
        => result.CompensateAsync(compensate);
}
