namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Requires a successful result value to be non-null.
    /// If the current Result is failed, returns a failed Result with the same errors.
    /// If the current Result is successful but the value is null, returns a failed Result with the provided error message.
    /// </summary>
    /// <typeparam name="TValue">The reference type contained in the Result.</typeparam>
    /// <param name="result">The result whose value is required to be non-null.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A successful Result with a non-null value or a failed Result.</returns>
    public static Result<TValue> Required<TValue>(this Result<TValue?> result, string errorMessage)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (result.IsFailed)
        {
            return Result.Fail<TValue>(result.Errors);
        }

        return result.Value is null ? Result.Fail<TValue>(errorMessage) : Result.Ok(result.Value);
    }

    /// <summary>
    /// Requires a successful nullable struct result value to have a value.
    /// If the current Result is failed, returns a failed Result with the same errors.
    /// If the current Result is successful but the value is null, returns a failed Result with the provided error message.
    /// </summary>
    /// <typeparam name="TValue">The value type contained in the nullable Result.</typeparam>
    /// <param name="result">The result whose nullable value is required to be present.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A successful Result with a non-null value or a failed Result.</returns>
    public static Result<TValue> Required<TValue>(this Result<TValue?> result, string errorMessage)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (result.IsFailed)
        {
            return Result.Fail<TValue>(result.Errors);
        }

        return result.Value.HasValue ? Result.Ok(result.Value.Value) : Result.Fail<TValue>(errorMessage);
    }
}
