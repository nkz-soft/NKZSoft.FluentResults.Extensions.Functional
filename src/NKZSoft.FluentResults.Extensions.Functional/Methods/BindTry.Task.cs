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
    public static async Task<Result> BindTryAsync(this Task<Result> resultTask, Func<Task<Result>> func, Func<Exception, string>? errorHandler = null)
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
    public static async Task<Result<TValue>> BindTryAsync<TValue>(this Task<Result> resultTask, Func<Task<Result<TValue>>> func, Func<Exception, string>? errorHandler = null)
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
    public static async Task<Result> BindTryAsync<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> func, Func<Exception, string>? errorHandler = null)
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
    public static async Task<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, Task<Result<TValueOut>>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindTryAsync(func, errorHandler).ConfigureAwait(false);
    }
}
