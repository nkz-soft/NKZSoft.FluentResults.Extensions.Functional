namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the specified error message.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the specified error messages.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorPredicate">A function that returns a list of errors to use if the condition is not met.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result Ensure(this Result result, Func<bool> predicate, Func<IList<IError>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail(errorPredicate()) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that returns a Result. If the Result is failed, the original Result is failed with the errors from the Result.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result Ensure(this Result result, Func<Result> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that returns a Result. If the Result is failed, the original Result is failed with the errors from the Result.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result Ensure<T>(this Result result, Func<Result<T>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the specified error message.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, Func<bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail<TValue>(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the errors from the error predicate.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorPredicate">A function that returns a list of errors to use if the condition is not met.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, Func<bool> predicate, Func<IList<IError>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail<TValue>(errorPredicate()) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that returns a Result. If the Result is failed, the original Result is failed with the errors from the Result.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, Func<Result<TValue>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the predicate.</typeparam>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that returns a Result. If the Result is failed, the original Result is failed with the errors from the Result.</param>
    /// <returns>A Result that is failed if the condition is not met, otherwise the original Result.</returns>
    public static Result<TValue> Ensure<T, TValue>(this Result<TValue> result, Func<Result<T>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }
}
