namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Creates a successful Result containing the value produced by the specified task.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="valueTask">The task that produces the value.</param>
    /// <returns>A successful Result containing the resolved value.</returns>
    public static async Task<Result<TValue>> OfAsync<TValue>(Task<TValue> valueTask)
    {
        ArgumentNullException.ThrowIfNull(valueTask);

        var value = await valueTask.ConfigureAwait(false);

        return Result.Ok(value);
    }

    /// <summary>
    /// Creates a successful Result containing the value produced by the specified asynchronous function.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="func">The asynchronous function that produces the value.</param>
    /// <returns>A successful Result containing the resolved value.</returns>
    public static async Task<Result<TValue>> OfAsync<TValue>(Func<Task<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var value = await func().ConfigureAwait(false);

        return Result.Ok(value);
    }
}
