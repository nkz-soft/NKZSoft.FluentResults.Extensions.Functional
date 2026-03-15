namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds a successful result and converts thrown exceptions into failed results.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async Task<Result> BindTryAsync(this Result result, Func<Task<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var output = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    /// <summary>
    /// Binds a successful result and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async Task<Result<TValue>> BindTryAsync<TValue>(this Result result, Func<Task<Result<TValue>>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValue>(result.Errors);
        }

        var output = await TryAsync(func, errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    /// <summary>
    /// Binds a successful result and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async Task<Result> BindTryAsync<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> func, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }

        var output = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }

    /// <summary>
    /// Binds a successful result and converts thrown exceptions into failed results.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <typeparam name="TValueOut">The type of the bound result value.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <param name="errorHandler">The optional handler that maps thrown exceptions to error messages.</param>
    /// <returns>A task that returns the bound result, or a failed result when the source is failed or the function throws an exception.</returns>
    public static async Task<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Task<Result<TValueOut>>> func,
        Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValueOut>(result.Errors);
        }

        var output = await TryAsync(() => func(result.Value), errorHandler).ConfigureAwait(false);
        return output.Bind(static inner => inner);
    }
}
