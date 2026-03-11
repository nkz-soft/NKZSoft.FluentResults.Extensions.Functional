namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result> CompensateAsync(this Task<Result> resultTask, Func<Task<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result> CompensateAsync(
        this Task<Result> resultTask,
        Func<IReadOnlyCollection<IError>, Task<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result<TValue>> CompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<Task<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result<TValue>> CompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, Task<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result> CompensateAsync(
        this Task<Result> resultTask,
        Func<ValueTask<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result> CompensateAsync(
        this Task<Result> resultTask,
        Func<IReadOnlyCollection<IError>, ValueTask<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result<TValue>> CompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<ValueTask<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">Task producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A task containing the original successful result or the fallback result.</returns>
    public static async Task<Result<TValue>> CompensateAsync<TValue>(
        this Task<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, ValueTask<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }
}
