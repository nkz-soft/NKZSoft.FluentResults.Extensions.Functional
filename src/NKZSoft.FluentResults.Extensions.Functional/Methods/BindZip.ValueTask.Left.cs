namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds an asynchronous result and combines the original value with the bound value into a tuple.
    /// </summary>
    /// <typeparam name="TValue">The type of the source result value.</typeparam>
    /// <typeparam name="TValueBind">The type of the value produced by the binding function.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a result containing the original value together with the bound value, or the encountered errors.</returns>
    public static async ValueTask<Result<(TValue First, TValueBind Second)>> BindZipAsync<TValue, TValueBind>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    /// <summary>
    /// Binds an asynchronous result and combines the original value with the bound value into a tuple.
    /// </summary>
    /// <typeparam name="T1">The type of the first tuple value.</typeparam>
    /// <typeparam name="T2">The type of the second tuple value.</typeparam>
    /// <typeparam name="TValueBind">The type of the value produced by the binding function.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a result containing the original value together with the bound value, or the encountered errors.</returns>
    public static async ValueTask<Result<(T1 First, T2 Second, TValueBind Third)>> BindZipAsync<T1, T2, TValueBind>(
        this ValueTask<Result<(T1, T2)>> resultTask,
        Func<T1, T2, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    /// <summary>
    /// Binds an asynchronous result and combines the original value with the bound value into a tuple.
    /// </summary>
    /// <typeparam name="T1">The type of the first tuple value.</typeparam>
    /// <typeparam name="T2">The type of the second tuple value.</typeparam>
    /// <typeparam name="T3">The type of the third tuple value.</typeparam>
    /// <typeparam name="TValueBind">The type of the value produced by the binding function.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a result containing the original value together with the bound value, or the encountered errors.</returns>
    public static async ValueTask<Result<(T1, T2, T3, TValueBind)>> BindZipAsync<T1, T2, T3, TValueBind>(
        this ValueTask<Result<(T1, T2, T3)>> resultTask,
        Func<T1, T2, T3, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    /// <summary>
    /// Binds an asynchronous result and combines the original value with the bound value into a tuple.
    /// </summary>
    /// <typeparam name="T1">The type of the first tuple value.</typeparam>
    /// <typeparam name="T2">The type of the second tuple value.</typeparam>
    /// <typeparam name="T3">The type of the third tuple value.</typeparam>
    /// <typeparam name="T4">The type of the fourth tuple value.</typeparam>
    /// <typeparam name="TValueBind">The type of the value produced by the binding function.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a result containing the original value together with the bound value, or the encountered errors.</returns>
    public static async ValueTask<Result<(T1, T2, T3, T4, TValueBind)>> BindZipAsync<T1, T2, T3, T4, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4)>> resultTask,
        Func<T1, T2, T3, T4, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    /// <summary>
    /// Binds an asynchronous result and combines the original value with the bound value into a tuple.
    /// </summary>
    /// <typeparam name="T1">The type of the first tuple value.</typeparam>
    /// <typeparam name="T2">The type of the second tuple value.</typeparam>
    /// <typeparam name="T3">The type of the third tuple value.</typeparam>
    /// <typeparam name="T4">The type of the fourth tuple value.</typeparam>
    /// <typeparam name="T5">The type of the fifth tuple value.</typeparam>
    /// <typeparam name="TValueBind">The type of the value produced by the binding function.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a result containing the original value together with the bound value, or the encountered errors.</returns>
    public static async ValueTask<Result<(T1, T2, T3, T4, T5, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4, T5)>> resultTask,
        Func<T1, T2, T3, T4, T5, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    /// <summary>
    /// Binds an asynchronous result and combines the original value with the bound value into a tuple.
    /// </summary>
    /// <typeparam name="T1">The type of the first tuple value.</typeparam>
    /// <typeparam name="T2">The type of the second tuple value.</typeparam>
    /// <typeparam name="T3">The type of the third tuple value.</typeparam>
    /// <typeparam name="T4">The type of the fourth tuple value.</typeparam>
    /// <typeparam name="T5">The type of the fifth tuple value.</typeparam>
    /// <typeparam name="T6">The type of the sixth tuple value.</typeparam>
    /// <typeparam name="TValueBind">The type of the value produced by the binding function.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a result containing the original value together with the bound value, or the encountered errors.</returns>
    public static async ValueTask<Result<(T1, T2, T3, T4, T5, T6, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, T6, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4, T5, T6)>> resultTask,
        Func<T1, T2, T3, T4, T5, T6, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    /// <summary>
    /// Binds an asynchronous result and combines the original value with the bound value into a tuple.
    /// </summary>
    /// <typeparam name="T1">The type of the first tuple value.</typeparam>
    /// <typeparam name="T2">The type of the second tuple value.</typeparam>
    /// <typeparam name="T3">The type of the third tuple value.</typeparam>
    /// <typeparam name="T4">The type of the fourth tuple value.</typeparam>
    /// <typeparam name="T5">The type of the fifth tuple value.</typeparam>
    /// <typeparam name="T6">The type of the sixth tuple value.</typeparam>
    /// <typeparam name="T7">The type of the seventh tuple value.</typeparam>
    /// <typeparam name="TValueBind">The type of the value produced by the binding function.</typeparam>
    /// <param name="resultTask">The asynchronous operation that produces the source result.</param>
    /// <param name="func">The function to execute when the operation runs.</param>
    /// <returns>A task that returns a result containing the original value together with the bound value, or the encountered errors.</returns>
    public static async ValueTask<Result<(T1, T2, T3, T4, T5, T6, T7, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, T6, T7, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4, T5, T6, T7)>> resultTask,
        Func<T1, T2, T3, T4, T5, T6, T7, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }
}
