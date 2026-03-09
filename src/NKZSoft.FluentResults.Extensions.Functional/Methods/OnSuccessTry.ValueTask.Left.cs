namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes the action when the awaited result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="action">Action to execute when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result, or the outcome of executing the action via <see cref="Try(Action,Func{Exception,string}?)"/>.</returns>
    public static async ValueTask<Result> OnSuccessTryAsync(this ValueTask<Result> resultTask, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);

        return result.OnSuccessTry(action, errorHandler);
    }

    /// <summary>
    /// Executes the action when the awaited result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">Type of the source result value.</typeparam>
    /// <param name="resultTask">ValueTask producing the source result.</param>
    /// <param name="action">Action to execute with the source value when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result converted to <see cref="Result"/>, or the outcome of executing the action via <see cref="Try(Action,Func{Exception,string}?)"/>.</returns>
    public static async ValueTask<Result> OnSuccessTryAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = await resultTask.ConfigureAwait(false);

        return result.OnSuccessTry(action, errorHandler);
    }
}
