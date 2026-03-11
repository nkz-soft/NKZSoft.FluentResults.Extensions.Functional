namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result OnFailureCompensate(this Result result, Func<Result> compensate)
        => result.Compensate(compensate);

    /// <summary>
    /// Executes fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result OnFailureCompensate(this Result result, Func<IReadOnlyCollection<IError>, Result> compensate)
        => result.Compensate(compensate);

    /// <summary>
    /// Executes fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result<TValue> OnFailureCompensate<TValue>(this Result<TValue> result, Func<Result<TValue>> compensate)
        => result.Compensate(compensate);

    /// <summary>
    /// Executes fallback logic only when the source result is failed; otherwise returns the source result.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result<TValue> OnFailureCompensate<TValue>(
        this Result<TValue> result,
        Func<IReadOnlyCollection<IError>, Result<TValue>> compensate)
        => result.Compensate(compensate);
}
