namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the original successful result, or the fallback result when the source is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result Compensate(this Result result, Func<Result> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate() : result;
    }

    /// <summary>
    /// Returns the original successful result, or the fallback result when the source is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result Compensate(this Result result, Func<IReadOnlyCollection<IError>, Result> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate(result.Errors) : result;
    }

    /// <summary>
    /// Returns the original successful result, or the fallback result when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result<TValue> Compensate<TValue>(this Result<TValue> result, Func<Result<TValue>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate() : result;
    }

    /// <summary>
    /// Returns the original successful result, or the fallback result when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>The original successful result or the fallback result.</returns>
    public static Result<TValue> Compensate<TValue>(
        this Result<TValue> result,
        Func<IReadOnlyCollection<IError>, Result<TValue>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate(result.Errors) : result;
    }
}
