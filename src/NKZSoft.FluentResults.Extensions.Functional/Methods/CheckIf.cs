namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a check when the condition is true.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="condition">Condition that controls check execution.</param>
    /// <param name="check">Check to execute when condition is true.</param>
    /// <returns>The original Result when condition is false; otherwise the Check result semantics.</returns>
    public static Result<TValue> CheckIf<TValue>(this Result<TValue> result, bool condition, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.Check(check) : result;
    }

    /// <summary>
    /// Executes a check when the condition is true.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="condition">Condition that controls check execution.</param>
    /// <param name="check">Value-based check to execute when condition is true.</param>
    /// <returns>The original Result when condition is false; otherwise the Check result semantics.</returns>
    public static Result<TValue> CheckIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, Result> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        return condition ? result.Check(check) : result;
    }

    /// <summary>
    /// Executes a check when the predicate is true for the Result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="predicate">Predicate that controls check execution.</param>
    /// <param name="check">Check to execute when predicate is true.</param>
    /// <returns>The original Result when predicate is false; otherwise the Check result semantics.</returns>
    public static Result<TValue> CheckIf<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    /// Executes a check when the predicate is true for the Result value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="predicate">Predicate that controls check execution.</param>
    /// <param name="check">Value-based check to execute when predicate is true.</param>
    /// <returns>The original Result when predicate is false; otherwise the Check result semantics.</returns>
    public static Result<TValue> CheckIf<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(check);

        return result.IsSuccess && predicate(result.Value) ? result.Check(check) : result;
    }
}
