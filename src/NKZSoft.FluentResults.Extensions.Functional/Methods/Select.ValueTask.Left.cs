namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Selects a new Result from a ValueTask result using a synchronous selector.
    /// This method is intended for LINQ query syntax and delegates to MapAsync.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the source Result.</typeparam>
    /// <typeparam name="TValueOut">The type of the value returned by the selector.</typeparam>
    /// <param name="resultTask">The ValueTask that produces the source Result.</param>
    /// <param name="selector">The mapping function.</param>
    /// <returns>A ValueTask containing the selected Result.</returns>
    public static ValueTask<Result<TValueOut>> SelectAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, TValueOut> selector)
        => resultTask.MapAsync(selector);

    /// <summary>
    /// Selects a new Result from a ValueTask result using a synchronous selector.
    /// This method is intended for LINQ query syntax and delegates to MapAsync.
    /// </summary>
    /// <typeparam name="TValueOut">The type of the value returned by the selector.</typeparam>
    /// <param name="resultTask">The ValueTask that produces the source Result.</param>
    /// <param name="selector">The mapping function.</param>
    /// <returns>A ValueTask containing the selected Result.</returns>
    public static ValueTask<Result<TValueOut>> SelectAsync<TValueOut>(
        this ValueTask<Result> resultTask,
        Func<TValueOut> selector)
        => resultTask.MapAsync(selector);
}
