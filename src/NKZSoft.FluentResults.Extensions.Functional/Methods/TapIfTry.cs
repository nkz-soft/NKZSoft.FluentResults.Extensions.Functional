namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes an action when the supplied condition is true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result TapIfTry(this Result result, bool condition, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result<TValue> TapIfTry<TValue>(this Result<TValue> result, bool condition, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = Try(action, errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes an action when the supplied condition is true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result<TValue> TapIfTry<TValue>(this Result<TValue> result, bool condition, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed || !condition)
        {
            return result;
        }

        var attempt = Try(() => action(result.Value), errorHandler);
        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result TapIfTry(this Result result, Func<bool> predicate, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(() =>
        {
            if (predicate())
            {
                action();
            }
        }, errorHandler);

        return attempt.IsFailed ? attempt : result;
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result<TValue> TapIfTry<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Action action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(() =>
        {
            if (predicate(result.Value))
            {
                action();
            }
        }, errorHandler);

        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }

    /// <summary>
    /// Executes an action when the supplied predicate evaluates to true and the result is successful, converting exceptions to failures.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="action">The action to execute.</param>
    /// <param name="errorHandler">Optional exception-to-error-message mapper. Defaults to exception message.</param>
    /// <returns>The original result, or a failed result when an exception occurs.</returns>
    public static Result<TValue> TapIfTry<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Action<TValue> action, Func<Exception, string>? errorHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(action);

        if (result.IsFailed)
        {
            return result;
        }

        var attempt = Try(() =>
        {
            if (predicate(result.Value))
            {
                action(result.Value);
            }
        }, errorHandler);

        return attempt.IsFailed ? Result.Fail<TValue>(attempt.Errors) : result;
    }
}
