namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the specified error message.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result> EnsureAsync(this Result result,
        Func<ValueTask<bool>> predicate,
        string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (result.IsFailed)
        {
            return result;
        }

        return !await predicate().ConfigureAwait(false) ? Result.Fail(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors specified by the error predicate.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorPredicate">A function that returns a list of errors if the condition is not met.</param>
    /// <returns>A Task of Result that is failed with the specified errors if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result> EnsureAsync(this Result result,
        Func<ValueTask<bool>> predicate,
        Func<Task<IList<IError>>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        if (result.IsFailed)
        {
            return result;
        }

        return !await predicate().ConfigureAwait(false)
            ? Result.Fail(await errorPredicate().ConfigureAwait(false))
            : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result. If the Result is failed, the function is considered to be not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if predicate is null.</exception>
    public static async ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<Result>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate().ConfigureAwait(false);

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result. If the Result is failed, the function is considered to be not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if predicate is null.</exception>
    public static async ValueTask<Result> EnsureAsync<T>(this Result result, Func<ValueTask<Result<T>>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate();

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the specified error message.
    /// </summary>
    /// <typeparam name="TValue">The type of the result value.</typeparam>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result<TValue>> EnsureAsync<TValue>(this Result<TValue> result,
        Func<ValueTask<bool>> predicate,
        string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (result.IsFailed)
        {
            return result;
        }

        return !await predicate().ConfigureAwait(false) ? Result.Fail<TValue>(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors specified by the error predicate.
    /// </summary>
    /// <typeparam name="TValue">The type of the result value.</typeparam>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorPredicate">A function that returns a list of errors if the condition is not met.</param>
    /// <returns>A Task of Result that is failed with the specified errors if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result<TValue>> EnsureAsync<TValue>(this Result<TValue> result,
        Func<ValueTask<bool>> predicate,
        Func<ValueTask<IList<IError>>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        if (result.IsFailed)
        {
            return result;
        }

        return !await predicate().ConfigureAwait(false)
            ? Result.Fail<TValue>(await errorPredicate().ConfigureAwait(false))
            : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="TValue">The type of the result value.</typeparam>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result. If the Result is failed, the function is considered to be not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if predicate is null.</exception>
    public static async ValueTask<Result<TValue>> EnsureAsync<TValue>(this Result<TValue> result,
        Func<ValueTask<Result<TValue>>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate().ConfigureAwait(false);

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the predicate result.</typeparam>
    /// <typeparam name="TValue">The type of the result value.</typeparam>
    /// <param name="result">The Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result. If the Result is failed, the function is considered to be not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if predicate is null.</exception>
    public static async ValueTask<Result<TValue>> EnsureAsync<T, TValue>(this Result<TValue> result,
        Func<ValueTask<Result<T>>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate().ConfigureAwait(false);

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }
}
