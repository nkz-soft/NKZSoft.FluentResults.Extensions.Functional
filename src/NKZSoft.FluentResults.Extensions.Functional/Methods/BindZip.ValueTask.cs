namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async ValueTask<Result<(TValue First, TValueBind Second)>> BindZipAsync<TValue, TValueBind>(
        this ValueTask<Result<TValue>> resultTask,
        Func<TValue, ValueTask<Result<TValueBind>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindZipAsync(func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<(T1 First, T2 Second, TValueBind Third)>> BindZipAsync<T1, T2, TValueBind>(
        this ValueTask<Result<(T1, T2)>> resultTask,
        Func<T1, T2, ValueTask<Result<TValueBind>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindZipAsync(func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<(T1, T2, T3, TValueBind)>> BindZipAsync<T1, T2, T3, TValueBind>(
        this ValueTask<Result<(T1, T2, T3)>> resultTask,
        Func<T1, T2, T3, ValueTask<Result<TValueBind>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindZipAsync(func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<(T1, T2, T3, T4, TValueBind)>> BindZipAsync<T1, T2, T3, T4, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4)>> resultTask,
        Func<T1, T2, T3, T4, ValueTask<Result<TValueBind>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindZipAsync(func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<(T1, T2, T3, T4, T5, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4, T5)>> resultTask,
        Func<T1, T2, T3, T4, T5, ValueTask<Result<TValueBind>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindZipAsync(func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<(T1, T2, T3, T4, T5, T6, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, T6, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4, T5, T6)>> resultTask,
        Func<T1, T2, T3, T4, T5, T6, ValueTask<Result<TValueBind>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindZipAsync(func).ConfigureAwait(false);
    }

    public static async ValueTask<Result<(T1, T2, T3, T4, T5, T6, T7, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, T6, T7, TValueBind>(
        this ValueTask<Result<(T1, T2, T3, T4, T5, T6, T7)>> resultTask,
        Func<T1, T2, T3, T4, T5, T6, T7, ValueTask<Result<TValueBind>>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return await result.BindZipAsync(func).ConfigureAwait(false);
    }
}
