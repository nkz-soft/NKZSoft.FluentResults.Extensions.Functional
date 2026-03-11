namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result> CompensateAsync(
        this ValueTask<Result> resultTask,
        Func<ValueTask<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result> CompensateAsync(
        this ValueTask<Result> resultTask,
        Func<IReadOnlyCollection<IError>, ValueTask<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result<TValue>> CompensateAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<ValueTask<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result<TValue>> CompensateAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, ValueTask<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result> CompensateAsync(
        this ValueTask<Result> resultTask,
        Func<Task<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result> CompensateAsync(
        this ValueTask<Result> resultTask,
        Func<IReadOnlyCollection<IError>, Task<Result>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result<TValue>> CompensateAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<Task<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the original successful value-task result, or asynchronously executes the fallback when the source is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="compensate">Asynchronous fallback factory executed only when the source is failed.</param>
    /// <returns>A ValueTask containing the original successful result or the fallback result.</returns>
    public static async ValueTask<Result<TValue>> CompensateAsync<TValue>(
        this ValueTask<Result<TValue>> resultTask,
        Func<IReadOnlyCollection<IError>, Task<Result<TValue>>> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);

        var result = await resultTask.ConfigureAwait(false);
        return await result.CompensateAsync(compensate).ConfigureAwait(false);
    }
}
