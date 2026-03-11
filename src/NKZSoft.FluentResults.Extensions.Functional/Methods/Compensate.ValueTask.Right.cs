namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static ValueTask<Result> CompensateAsync(this Result result, Func<ValueTask<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate() : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static ValueTask<Result> CompensateAsync(
        this Result result,
        Func<IReadOnlyCollection<IError>, ValueTask<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate(result.Errors) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static ValueTask<Result<TValue>> CompensateAsync<TValue>(
        this Result<TValue> result,
        Func<ValueTask<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate() : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static ValueTask<Result<TValue>> CompensateAsync<TValue>(
        this Result<TValue> result,
        Func<IReadOnlyCollection<IError>, ValueTask<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate(result.Errors) : ValueTask.FromResult(result);
    }
}
