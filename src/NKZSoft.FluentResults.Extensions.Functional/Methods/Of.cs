namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Creates a successful Result containing the specified value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value to wrap.</param>
    /// <returns>A successful Result containing <paramref name="value" />.</returns>
    public static Result<TValue> Of<TValue>(TValue value) => Result.Ok(value);

    /// <summary>
    /// Creates a successful Result containing the value returned by the specified function.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="func">The function that produces the value.</param>
    /// <returns>A successful Result containing the returned value.</returns>
    public static Result<TValue> Of<TValue>(Func<TValue> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return Result.Ok(func());
    }
}
