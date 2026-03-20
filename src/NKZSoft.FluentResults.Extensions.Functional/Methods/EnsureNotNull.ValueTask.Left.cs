namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Ensures a successful ValueTask reference type result value is non-null.
    /// </summary>
    /// <typeparam name="TValue">The reference type contained in the Result.</typeparam>
    /// <param name="resultTask">The ValueTask that produces the Result.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A ValueTask containing a successful Result with a non-null value or a failed Result.</returns>
    public static async ValueTask<Result<TValue>> EnsureNotNullAsync<TValue>(this ValueTask<Result<TValue?>> resultTask, string errorMessage)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        return result.EnsureNotNull(errorMessage);
    }
    /// <summary>
    /// Ensures a successful ValueTask reference type result value is non-null and returns the specified rich error when null.
    /// </summary>
    public static async ValueTask<Result<TValue>> EnsureNotNullAsync<TValue>(this ValueTask<Result<TValue?>> resultTask, IError error)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(error);

        var result = await resultTask.ConfigureAwait(false);
        return result.EnsureNotNull(error);
    }
    /// <summary>
    /// Ensures a successful ValueTask reference type result value is non-null and returns the specified rich errors when null.
    /// </summary>
    public static async ValueTask<Result<TValue>> EnsureNotNullAsync<TValue>(this ValueTask<Result<TValue?>> resultTask, IEnumerable<IError> errors)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(errors);

        var result = await resultTask.ConfigureAwait(false);
        return result.EnsureNotNull(errors);
    }

    /// <summary>
    /// Ensures a successful ValueTask nullable struct result value has a value.
    /// </summary>
    /// <typeparam name="TValue">The value type contained in the nullable Result.</typeparam>
    /// <param name="resultTask">The ValueTask that produces the Result.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A ValueTask containing a successful Result with a non-null value or a failed Result.</returns>
    public static async ValueTask<Result<TValue>> EnsureNotNullAsync<TValue>(this ValueTask<Result<TValue?>> resultTask, string errorMessage)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        return result.EnsureNotNull(errorMessage);
    }
    /// <summary>
    /// Ensures a successful ValueTask nullable struct result value has a value and returns the specified rich error when null.
    /// </summary>
    public static async ValueTask<Result<TValue>> EnsureNotNullAsync<TValue>(this ValueTask<Result<TValue?>> resultTask, IError error)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(error);

        var result = await resultTask.ConfigureAwait(false);
        return result.EnsureNotNull(error);
    }
    /// <summary>
    /// Ensures a successful ValueTask nullable struct result value has a value and returns the specified rich errors when null.
    /// </summary>
    public static async ValueTask<Result<TValue>> EnsureNotNullAsync<TValue>(this ValueTask<Result<TValue?>> resultTask, IEnumerable<IError> errors)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(errors);

        var result = await resultTask.ConfigureAwait(false);
        return result.EnsureNotNull(errors);
    }
}
