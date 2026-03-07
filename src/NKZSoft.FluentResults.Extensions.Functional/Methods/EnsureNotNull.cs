namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Ensures a successful reference type result value is non-null.
    /// If the source result is failed, returns a failed Result with the same errors.
    /// If the source result is successful but the value is null, returns a failed Result with the provided error message.
    /// </summary>
    /// <typeparam name="TValue">The reference type contained in the Result.</typeparam>
    /// <param name="result">The result whose value must be non-null.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A successful Result with a non-null value or a failed Result.</returns>
    public static Result<TValue> EnsureNotNull<TValue>(this Result<TValue?> result, string errorMessage)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Required(errorMessage);
    }

    /// <summary>
    /// Ensures a successful nullable struct result value has a value.
    /// If the source result is failed, returns a failed Result with the same errors.
    /// If the source result is successful but the value is null, returns a failed Result with the provided error message.
    /// </summary>
    /// <typeparam name="TValue">The value type contained in the nullable Result.</typeparam>
    /// <param name="result">The result whose nullable value must be present.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A successful Result with a non-null value or a failed Result.</returns>
    public static Result<TValue> EnsureNotNull<TValue>(this Result<TValue?> result, string errorMessage)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Required(errorMessage);
    }
}
