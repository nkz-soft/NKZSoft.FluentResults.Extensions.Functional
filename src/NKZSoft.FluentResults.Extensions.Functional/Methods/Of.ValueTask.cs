namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Creates a successful Result containing the value produced by the specified value task.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="valueTask">The value task that produces the value.</param>
    /// <returns>A successful Result containing the resolved value.</returns>
    public static async ValueTask<Result<TValue>> OfAsync<TValue>(ValueTask<TValue> valueTask)
    {
        var value = await valueTask.ConfigureAwait(false);

        return Result.Ok(value);
    }

    /// <summary>
    /// Creates a successful Result containing the value produced by the specified asynchronous value-task function.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="func">The asynchronous value-task function that produces the value.</param>
    /// <returns>A successful Result containing the resolved value.</returns>
    public static async ValueTask<Result<TValue>> OfAsync<TValue>(Func<ValueTask<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var value = await func().ConfigureAwait(false);

        return Result.Ok(value);
    }
}
