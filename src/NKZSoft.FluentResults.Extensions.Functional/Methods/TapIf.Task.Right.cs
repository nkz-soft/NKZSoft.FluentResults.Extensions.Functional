namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is successful.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task<Result> TapIfAsync(this Result result, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapAsync(func) : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, bool condition, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapAsync(func) : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function when the supplied condition is true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, bool condition, Func<TValue, Task> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapAsync(func) : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task<Result> TapIfAsync(this Result result, Func<bool> predicate, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate()
            ? result.TapAsync(func)
            : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<Task> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.TapAsync(func)
            : Task.FromResult(result);
    }

    /// <summary>
    /// Executes a task function when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The task function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static Task<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, Task> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.TapAsync(func)
            : Task.FromResult(result);
    }

    // ValueTask-based overloads for Result are in TapIf.ValueTask.Right.cs
}
