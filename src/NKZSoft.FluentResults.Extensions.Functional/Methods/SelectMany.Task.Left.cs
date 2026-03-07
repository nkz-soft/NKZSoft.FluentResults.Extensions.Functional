namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Projects each successful task Result value to another Result and combines both values.
    /// This method is intended for LINQ query syntax.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueBind">The bound value type.</typeparam>
    /// <typeparam name="TValueOut">The projected value type.</typeparam>
    /// <param name="resultTask">The task producing the source Result.</param>
    /// <param name="func">Function that binds the source value to another Result.</param>
    /// <param name="project">Function that combines source and bound values.</param>
    /// <returns>A task containing the projected Result.</returns>
    public static async Task<Result<TValueOut>> SelectManyAsync<TValue, TValueBind, TValueOut>(
        this Task<Result<TValue>> resultTask,
        Func<TValue, Result<TValueBind>> func,
        Func<TValue, TValueBind, TValueOut> project)
    {
        ArgumentNullException.ThrowIfNull(func);
        ArgumentNullException.ThrowIfNull(project);

        var result = await resultTask.ConfigureAwait(false);
        return result.SelectMany(func, project);
    }
}
