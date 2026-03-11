namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the original successful task result, or the fallback result when the source is failed.
    /// </summary>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result> CompensateAsync(this Task<Result> resultTask, Func<Result> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return result.Compensate(compensate);
    }

    /// <summary>
    /// Returns the original successful task result, or the fallback result when the source is failed.
    /// </summary>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result> CompensateAsync(
        this Task<Result> resultTask,
        Func<IReadOnlyCollection<IError>, Result> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return result.Compensate(compensate);
    }

    /// <summary>
    /// Returns the original successful task result, or the fallback result when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result<TValue>> CompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<Result<TValue>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return result.Compensate(compensate);
    }

    /// <summary>
    /// Returns the original successful task result, or the fallback result when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result<TValue>> CompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, Result<TValue>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return result.Compensate(compensate);
    }
}
