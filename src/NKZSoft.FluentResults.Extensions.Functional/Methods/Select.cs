namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Selects a new Result from the current result.
    /// This method is intended for LINQ query syntax and delegates to Map.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the source Result.</typeparam>
    /// <typeparam name="TValueOut">The type of the value returned by the selector.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="selector">The mapping function.</param>
    /// <returns>A new Result containing the selected value or the original errors.</returns>
    public static Result<TValueOut> Select<TValue, TValueOut>(this Result<TValue> result, Func<TValue, TValueOut> selector)
        => result.Map(selector);

    /// <summary>
    /// Selects a new Result from the current result.
    /// This method is intended for LINQ query syntax and delegates to Map.
    /// </summary>
    /// <typeparam name="TValueOut">The type of the value returned by the selector.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="selector">The mapping function.</param>
    /// <returns>A new Result containing the selected value or the original errors.</returns>
    public static Result<TValueOut> Select<TValueOut>(this Result result, Func<TValueOut> selector)
        => result.Map(selector);
}
