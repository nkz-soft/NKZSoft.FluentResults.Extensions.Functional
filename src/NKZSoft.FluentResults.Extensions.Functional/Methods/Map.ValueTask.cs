namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously maps a Result from a ValueTask using a function that returns a ValueTask.
    /// </summary>
    /// <typeparam name="TValue">The type of the value returned by the function.</typeparam>
    /// <param name="resultTask">The ValueTask that produces the Result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <returns>A ValueTask containing the mapped Result.</returns>
    public static async ValueTask<Result<TValue>> MapAsync<TValue>(
        this ValueTask<Result> resultTask,
        Func<ValueTask<TValue>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously maps a Result from a ValueTask using a function that returns a ValueTask.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <typeparam name="TValueOut">The type of the value returned by the function.</typeparam>
    /// <param name="resultTask">The ValueTask that produces the Result.</param>
    /// <param name="func">The asynchronous mapping function.</param>
    /// <returns>A ValueTask containing the mapped Result.</returns>
    public static async ValueTask<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, ValueTask<TValueOut>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func).ConfigureAwait(false);
    }
}
