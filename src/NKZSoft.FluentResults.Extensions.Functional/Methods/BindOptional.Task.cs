namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds an optional result value from an asynchronous operation only when a value is present.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <typeparam name="TValueOut">The type of the bound result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a successful optional result when the source has no value, the original errors when the source is failed, or the bound result when a value is present.</returns>
    public static async Task<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Task<Result<TValue?>> resultTask,
        Func<TValue, Task<Result<TValueOut?>>> func)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindOptionalAsync(func).ConfigureAwait(false);
    }

    /// <summary>
    /// Binds an optional result value from an asynchronous operation only when a value is present.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <typeparam name="TValueOut">The type of the bound result value.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a successful optional result when the source has no value, the original errors when the source is failed, or the bound result when a value is present.</returns>
    public static async Task<Result<TValueOut?>> BindOptionalAsync<TValue, TValueOut>(
        this Task<Result<TValue?>> resultTask,
        Func<TValue, Task<Result<TValueOut?>>> func)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindOptionalAsync(func).ConfigureAwait(false);
    }
}
