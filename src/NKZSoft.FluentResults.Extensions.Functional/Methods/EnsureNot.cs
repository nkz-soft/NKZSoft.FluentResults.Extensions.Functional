namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Ensures that a condition based on the result value is not met for a successful Result.
    /// If the condition is met, returns a failed Result with the specified error message.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates the result value and returns true when the condition is met.</param>
    /// <param name="errorMessage">The error message to use if the condition is met.</param>
    /// <returns>A Result that is failed when the condition is met, otherwise the original Result.</returns>
    public static Result<TValue> EnsureNot<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        return result.Ensure(value => !predicate(value), errorMessage);
    }
}
