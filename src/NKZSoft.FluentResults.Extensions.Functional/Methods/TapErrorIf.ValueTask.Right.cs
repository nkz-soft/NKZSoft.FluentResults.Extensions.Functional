namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the result is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static ValueTask<Result> TapErrorIfAsync(this Result result, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function when the supplied condition is true and the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this Result<TValue> result, bool condition, Func<ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function for each error when the supplied condition is true and the result is failed.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute for each error.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static ValueTask<Result> TapErrorIfAsync(this Result result, bool condition, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : ValueTask.FromResult(result);
    }

    /// <summary>
    /// Executes a valuetask function for each error when the supplied condition is true and the result is failed.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">Condition that controls whether the action runs.</param>
    /// <param name="func">The valuetask function to execute for each error.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static ValueTask<Result<TValue>> TapErrorIfAsync<TValue>(this Result<TValue> result, bool condition, Func<IError, ValueTask> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return condition ? result.TapErrorAsync(func) : ValueTask.FromResult(result);
    }
}
