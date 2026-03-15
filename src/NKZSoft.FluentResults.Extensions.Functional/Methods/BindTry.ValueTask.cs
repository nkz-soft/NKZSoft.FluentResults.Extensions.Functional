namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds a successful result from an asynchronous operation and converts thrown exceptions into failed results.
    /// </summary>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async ValueTask<Result> BindTryAsync(this ValueTask<Result> resultTask, Func<ValueTask<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Binds a successful result from an asynchronous operation and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async ValueTask<Result<TValue>> BindTryAsync<TValue>(this ValueTask<Result> resultTask, Func<ValueTask<Result<TValue>>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Binds a successful result from an asynchronous operation and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async ValueTask<Result> BindTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, ValueTask<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Binds a successful result from an asynchronous operation and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <typeparam name="TValueOut">The type of the bound result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async ValueTask<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, ValueTask<Result<TValueOut>>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }
}
