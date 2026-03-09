namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes the function when the awaited source result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="func">Function to execute when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result, or the outcome of executing the function via <see cref="TryAsync(Func{ValueTask},Func{Exception,string}?)"/>.</returns>
    public static async ValueTask<Result> OnSuccessTryAsync(this ValueTask<Result> resultTask, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);

        return await result.OnSuccessTryAsync(func, errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Executes the function when the awaited source result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">Type of the source result value.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="func">Function to execute with the source value when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result converted to <see cref="Result"/>, or the outcome of executing the function via <see cref="TryAsync(Func{ValueTask},Func{Exception,string}?)"/>.</returns>
    public static async ValueTask<Result> OnSuccessTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);

        return await result.OnSuccessTryAsync(func, errorHandler).ConfigureAwait(false);
    }
}
