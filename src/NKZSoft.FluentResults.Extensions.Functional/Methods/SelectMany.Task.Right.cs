namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Asynchronously projects each successful Result value to another Result and combines both values.
    /// This method is intended for LINQ query syntax.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueBind">The bound value type.</typeparam>
    /// <typeparam name="TValueOut">The projected value type.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="func">Asynchronous function that binds the source value to another Result.</param>
    /// <param name="project">Function that combines source and bound values.</param>
    /// <returns>A task containing the projected Result.</returns>
    public static async Task<Result<TValueOut>> SelectManyAsync<TValue, TValueBind, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Task<Result<TValueBind>>> func,
        Func<TValue, TValueBind, TValueOut> project)
    {
        ArgumentNullException.ThrowIfNull(func);
        ArgumentNullException.ThrowIfNull(project);

        if (result.IsFailed)
        {
            return Result.Fail<TValueOut>(result.Errors);
        }

        var value = result.Value;
        var bindResult = await func(value).ConfigureAwait(false);

        return bindResult.IsFailed
            ? Result.Fail<TValueOut>(bindResult.Errors)
            : Result.Ok(project(value, bindResult.Value));
    }
}
