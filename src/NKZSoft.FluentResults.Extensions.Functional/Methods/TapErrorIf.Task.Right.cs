namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static Task<Result> TapErrorIfAsync(this Result result, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static Task<Result<TValue>> TapErrorIfAsync<TValue>(this Result<TValue> result, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function for each error when the supplied condition is true and the result is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute for each error.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static Task<Result> TapErrorIfAsync(this Result result, bool condition, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function for each error when the supplied condition is true and the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute for each error.</param>
    /// <returns>A task that completes with the original result after the conditional callback finishes.</returns>
    public static Task<Result<TValue>> TapErrorIfAsync<TValue>(this Result<TValue> result, bool condition, Func<IError, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : Task.FromResult(result);
    }
}
