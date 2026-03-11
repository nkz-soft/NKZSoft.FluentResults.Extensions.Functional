namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static Task<Result> CompensateAsync(this Result result, Func<Task<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate() : Task.FromResult(result);
    }

    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static Task<Result> CompensateAsync(
        this Result result,
        Func<IReadOnlyCollection<IError>, Task<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate(result.Errors) : Task.FromResult(result);
    }

    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static Task<Result<TValue>> CompensateAsync<TValue>(
        this Result<TValue> result,
        Func<Task<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate() : Task.FromResult(result);
    }

    /// <summary>
    /// Returns the original successful result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static Task<Result<TValue>> CompensateAsync<TValue>(
        this Result<TValue> result,
        Func<IReadOnlyCollection<IError>, Task<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsFailed ? compensate(result.Errors) : Task.FromResult(result);
    }
}
