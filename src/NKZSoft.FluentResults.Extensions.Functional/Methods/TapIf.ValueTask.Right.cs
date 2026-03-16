namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the result is successful.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static ValueTask<Result> TapIfAsync(this Result result, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapAsync(func) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static ValueTask<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapAsync(func) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static ValueTask<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, bool condition, Func<TValue, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapAsync(func) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static ValueTask<Result> TapIfAsync(this Result result, Func<bool> predicate, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate()
            ? result.TapAsync(func)
            : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static ValueTask<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.TapAsync(func)
            : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied predicate evaluates to true and the result is successful.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">Predicate that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A valuetask representing the asynchronous operation.</returns>
    public static ValueTask<Result<TValue>> TapIfAsync<TValue>(this Result<TValue> result, Func<TValue, bool> predicate, Func<TValue, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);

        return result.IsSuccess && predicate(result.Value)
            ? result.TapAsync(func)
            : ValueTask.FromResult(result);
    }
}
