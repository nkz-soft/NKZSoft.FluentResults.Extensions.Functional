namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes the function when the source result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">Function to execute when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result, or the outcome of executing the function via <see cref="TryAsync(Func{ValueTask},Func{Exception,string}?)"/>.</returns>
    public static ValueTask<Result> OnSuccessTryAsync(this Result result, Func<ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? ValueTask.FromResult(result)
            : TryAsync(func, errorHandler);
    }

    /// <summary>
    /// Executes the function when the source result is successful and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">Type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">Function to execute with the source value when the source result is successful.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original failed result converted to <see cref="Result"/>, or the outcome of executing the function via <see cref="TryAsync(Func{ValueTask},Func{Exception,string}?)"/>.</returns>
    public static ValueTask<Result> OnSuccessTryAsync<TValue>(this Result<TValue> result, Func<TValue, ValueTask> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        return result.IsFailed
            ? ValueTask.FromResult(result.ToResult())
            : TryAsync(() => func(result.Value), errorHandler);
    }
}
