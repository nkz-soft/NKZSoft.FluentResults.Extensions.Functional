namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds a task that returns a result to a function that returns a new result.
    /// </summary>
    /// <param name="resultTask">The task that returns a result.</param>
    /// <param name="func">The function that returns a new result.</param>
    /// <returns>A task that returns the bound result.</returns>
    public static async ValueTask<Result> BindAsync(this ValueTask<Result> resultTask, Func<Result> func)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.IternalBind(func);
    }

    /// <summary>
    /// Binds a task that returns a result to a function that returns a new result.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="resultTask">The task that returns a result.</param>
    /// <param name="func">The function that returns a new result.</param>
    /// <returns>A task that returns the bound result.</returns>
    public static async ValueTask<Result<TValue>> BindAsync<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, Result<TValue>> func)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.IternalBind(func);
    }
}
