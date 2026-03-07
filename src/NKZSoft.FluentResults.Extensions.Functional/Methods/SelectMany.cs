namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Projects each successful Result value to another Result and combines both values.
    /// This method is intended for LINQ query syntax.
    /// </summary>
    /// <typeparam name="TValue">The source value type.</typeparam>
    /// <typeparam name="TValueBind">The bound value type.</typeparam>
    /// <typeparam name="TValueOut">The projected value type.</typeparam>
    /// <param name="result">The source Result.</param>
    /// <param name="func">Function that binds the source value to another Result.</param>
    /// <param name="project">Function that combines source and bound values.</param>
    /// <returns>A Result containing the projected value, or failure errors from source/bind.</returns>
    public static Result<TValueOut> SelectMany<TValue, TValueBind, TValueOut>(
        this Result<TValue> result,
        Func<TValue, Result<TValueBind>> func,
        Func<TValue, TValueBind, TValueOut> project)
    {
        ArgumentNullException.ThrowIfNull(func);
        ArgumentNullException.ThrowIfNull(project);

        return result.Bind(value => func(value).Map(bindValue => project(value, bindValue)));
    }
}
