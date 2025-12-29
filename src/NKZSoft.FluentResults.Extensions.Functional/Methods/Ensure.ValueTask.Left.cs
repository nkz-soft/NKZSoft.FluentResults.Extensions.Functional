namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the specified error message.
    /// </summary>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask,
        Func<bool> predicate,
        string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the error predicate.
    /// </summary>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorPredicate">A function that returns a list of errors to use if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask,
        Func<bool> predicate,
        Func<IReadOnlyList<IError>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail(errorPredicate()) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that returns a Result. If the Result is failed, the original Result is failed with the errors from the Result.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<Result> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that returns a Result. If the Result is failed, the original Result is failed with the errors from the Result.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result> EnsureAsync<T>(this ValueTask<Result> resultTask, Func<Result<T>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the specified error message.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async ValueTask<Result<TValue>> EnsureAsync<TValue>(this ValueTask<Result<TValue>> resultTask,
        Func<bool> predicate,
        string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail<TValue>(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the specified error messages.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met.</param>
    /// <param name="errorPredicate">A function that returns a list of errors if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if predicate or errorPredicate is null.</exception>
    public static async ValueTask<Result<TValue>> EnsureAsync<TValue>(this ValueTask<Result<TValue>> resultTask,
        Func<bool> predicate,
        Func<IReadOnlyList<IError>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        return !predicate() ? Result.Fail<TValue>(errorPredicate()) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the error predicate.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result. If the Result is failed, the function is considered to be not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if predicate is null.</exception>
    public static async ValueTask<Result<TValue>> EnsureAsync<TValue>(this ValueTask<Result<TValue>> resultTask,
        Func<Result<TValue>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Result with the errors from the error predicate.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result of the predicate.</typeparam>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result. If the Result is failed, the function is considered to be not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if predicate is null.</exception>
    public static async ValueTask<Result<TValue>> EnsureAsync<T, TValue>(this ValueTask<Result<TValue>> resultTask,
        Func<Result<T>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = predicate();

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }
}
