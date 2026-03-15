namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds a successful nullable reference result only when the value is non-null.
    /// </summary>
    public static Result<TValueOut?> BindOptional<TValue, TValueOut>(
        this Result<TValue?> result,
        Func<TValue, Result<TValueOut?>> func)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValueOut?>(result.Errors);
        }

        return result.Value is null
            ? Result.Ok<TValueOut?>(default)
            : func(result.Value);
    }

    /// <summary>
    /// Binds a successful nullable struct result only when the value is present.
    /// </summary>
    public static Result<TValueOut?> BindOptional<TValue, TValueOut>(
        this Result<TValue?> result,
        Func<TValue, Result<TValueOut?>> func)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<TValueOut?>(result.Errors);
        }

        return result.Value.HasValue
            ? func(result.Value.Value)
            : Result.Ok<TValueOut?>(default);
    }
}
