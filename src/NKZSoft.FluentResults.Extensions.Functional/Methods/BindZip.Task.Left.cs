namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static async Task<Result<(TValue First, TValueBind Second)>> BindZipAsync<TValue, TValueBind>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    public static async Task<Result<(T1 First, T2 Second, TValueBind Third)>> BindZipAsync<T1, T2, TValueBind>(
        this Task<Result<(T1, T2)>> resultTask,
        Func<T1, T2, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    public static async Task<Result<(T1, T2, T3, TValueBind)>> BindZipAsync<T1, T2, T3, TValueBind>(
        this Task<Result<(T1, T2, T3)>> resultTask,
        Func<T1, T2, T3, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    public static async Task<Result<(T1, T2, T3, T4, TValueBind)>> BindZipAsync<T1, T2, T3, T4, TValueBind>(
        this Task<Result<(T1, T2, T3, T4)>> resultTask,
        Func<T1, T2, T3, T4, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    public static async Task<Result<(T1, T2, T3, T4, T5, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, TValueBind>(
        this Task<Result<(T1, T2, T3, T4, T5)>> resultTask,
        Func<T1, T2, T3, T4, T5, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    public static async Task<Result<(T1, T2, T3, T4, T5, T6, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, T6, TValueBind>(
        this Task<Result<(T1, T2, T3, T4, T5, T6)>> resultTask,
        Func<T1, T2, T3, T4, T5, T6, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }

    public static async Task<Result<(T1, T2, T3, T4, T5, T6, T7, TValueBind)>> BindZipAsync<T1, T2, T3, T4, T5, T6, T7, TValueBind>(
        this Task<Result<(T1, T2, T3, T4, T5, T6, T7)>> resultTask,
        Func<T1, T2, T3, T4, T5, T6, T7, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        var result = await resultTask.ConfigureAwait(false);
        return result.BindZip(func);
    }
}
