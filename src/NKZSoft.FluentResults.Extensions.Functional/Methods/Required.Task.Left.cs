namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Requires a successful task result value to be non-null.
    /// </summary>
    /// <typeparam name="TValue">The reference type contained in the Result.</typeparam>
    /// <param name="resultTask">The task that produces the Result.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A task containing a successful Result with a non-null value or a failed Result.</returns>
    public static async Task<Result<TValue>> RequiredAsync<TValue>(this Task<Result<TValue?>> resultTask, string errorMessage)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        return result.Required(errorMessage);
    }
    /// <summary>
    /// Requires a successful task result value to be non-null and returns the specified rich error when null.
    /// </summary>
    public static async Task<Result<TValue>> RequiredAsync<TValue>(this Task<Result<TValue?>> resultTask, IError error)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(error);

        var result = await resultTask.ConfigureAwait(false);
        return result.Required(error);
    }
    /// <summary>
    /// Requires a successful task result value to be non-null and returns the specified rich errors when null.
    /// </summary>
    public static async Task<Result<TValue>> RequiredAsync<TValue>(this Task<Result<TValue?>> resultTask, IEnumerable<IError> errors)
        where TValue : class
    {
        ArgumentNullException.ThrowIfNull(errors);

        var result = await resultTask.ConfigureAwait(false);
        return result.Required(errors);
    }

    /// <summary>
    /// Requires a successful nullable struct task result value to have a value.
    /// </summary>
    /// <typeparam name="TValue">The value type contained in the nullable Result.</typeparam>
    /// <param name="resultTask">The task that produces the Result.</param>
    /// <param name="errorMessage">The error message used when the value is null.</param>
    /// <returns>A task containing a successful Result with a non-null value or a failed Result.</returns>
    public static async Task<Result<TValue>> RequiredAsync<TValue>(this Task<Result<TValue?>> resultTask, string errorMessage)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        var result = await resultTask.ConfigureAwait(false);
        return result.Required(errorMessage);
    }
    /// <summary>
    /// Requires a successful nullable struct task result value to have a value and returns the specified rich error when null.
    /// </summary>
    public static async Task<Result<TValue>> RequiredAsync<TValue>(this Task<Result<TValue?>> resultTask, IError error)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(error);

        var result = await resultTask.ConfigureAwait(false);
        return result.Required(error);
    }
    /// <summary>
    /// Requires a successful nullable struct task result value to have a value and returns the specified rich errors when null.
    /// </summary>
    public static async Task<Result<TValue>> RequiredAsync<TValue>(this Task<Result<TValue?>> resultTask, IEnumerable<IError> errors)
        where TValue : struct
    {
        ArgumentNullException.ThrowIfNull(errors);

        var result = await resultTask.ConfigureAwait(false);
        return result.Required(errors);
    }
}
