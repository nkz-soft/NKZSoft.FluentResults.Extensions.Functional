namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Task of Result with the specified error message.
    /// </summary>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met. This function should return a Task of bool.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask,
        Func<Task<bool>> predicate,
        string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        return !await predicate().ConfigureAwait(false) ? Result.Fail(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Task of Result with the specified error.
    /// </summary>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met. This function should return a Task of bool.</param>
    /// <param name="errorPredicate">A function that returns a list of errors if the condition is not met. This function should return a Task of IReadOnlyList of IError.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask,
        Func<Task<bool>> predicate,
        Func<Task<IReadOnlyList<IError>>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        var result = await resultTask.ConfigureAwait(false);
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
    /// If the condition is not met, returns a failed Task of Result with the errors from the predicate.
    /// </summary>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result if the condition is met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<Result>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate().ConfigureAwait(false);

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Task of Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result of T if the condition is met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result> EnsureAsync<T>(this Task<Result> resultTask, Func<Task<Result<T>>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate();

        return predicateResult.IsFailed ? Result.Fail(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Task of Result with the specified error message.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met. This function should return a Task of bool.</param>
    /// <param name="errorMessage">The error message to use if the condition is not met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result<TValue>> EnsureAsync<TValue>(this Task<Result<TValue>> resultTask,
        Func<Task<bool>> predicate,
        string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        return !await predicate().ConfigureAwait(false) ? Result.Fail<TValue>(errorMessage) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Task of Result with the errors provided by the error predicate.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to true if the condition is met. This function should return a Task of bool.</param>
    /// <param name="errorPredicate">A function that provides the errors to use if the condition is not met. This function should return a Task of IReadOnlyList of IError.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result<TValue>> EnsureAsync<TValue>(this Task<Result<TValue>> resultTask,
        Func<Task<bool>> predicate,
        Func<Task<IReadOnlyList<IError>>> errorPredicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errorPredicate);

        var result = await resultTask.ConfigureAwait(false);
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
    /// If the condition is not met, returns a failed Task of Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result of TValue if the condition is met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result<TValue>> EnsureAsync<TValue>(this Task<Result<TValue>> resultTask,
        Func<Task<Result<TValue>>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate().ConfigureAwait(false);

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }

    /// <summary>
    /// Ensures that a condition is met for a successful Result asynchronously.
    /// If the condition is not met, returns a failed Task of Result with the errors from the predicate.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the predicate result.</typeparam>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="resultTask">The Task of Result to ensure.</param>
    /// <param name="predicate">A function that evaluates to a Result of T if the condition is met.</param>
    /// <returns>A Task of Result that is failed if the condition is not met, otherwise the original Task of Result.</returns>
    public static async Task<Result<TValue>> EnsureAsync<T, TValue>(this Task<Result<TValue>> resultTask,
        Func<Task<Result<T>>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return result;
        }

        var predicateResult = await predicate().ConfigureAwait(false);

        return predicateResult.IsFailed ? Result.Fail<TValue>(predicateResult.Errors) : result;
    }
}
