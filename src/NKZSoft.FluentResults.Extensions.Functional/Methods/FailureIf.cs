namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful.
    /// This method mirrors CSharpFunctionalExtensions naming and delegates to FluentResults semantics.
    /// </summary>
    /// <param name="isFailure">The condition that determines whether the Result is failed.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A failed Result when <paramref name="isFailure"/> is true; otherwise a successful Result.</returns>
    public static Result FailureIf(bool isFailure, string error) =>
        SuccessIf(!isFailure, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using a rich error object.
    /// </summary>
    public static Result FailureIf(bool isFailure, IError error) =>
        SuccessIf(!isFailure, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using rich error objects.
    /// </summary>
    public static Result FailureIf(bool isFailure, IEnumerable<IError> errors) =>
        SuccessIf(!isFailure, errors);

    /// <summary>
    /// Returns a Result that is failed when the predicate evaluates to true, otherwise successful.
    /// </summary>
    /// <param name="failurePredicate">Predicate that determines whether the Result is failed.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A failed Result when the predicate evaluates to true; otherwise a successful Result.</returns>
    public static Result FailureIf(Func<bool> failurePredicate, string error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailureIf(failurePredicate(), error);
    }
    /// <summary>
    /// Returns a Result that is failed when the predicate evaluates to true, otherwise successful, using a rich error object.
    /// </summary>
    public static Result FailureIf(Func<bool> failurePredicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailureIf(failurePredicate(), error);
    }
    /// <summary>
    /// Returns a Result that is failed when the predicate evaluates to true, otherwise successful, using rich error objects.
    /// </summary>
    public static Result FailureIf(Func<bool> failurePredicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailureIf(failurePredicate(), errors);
    }

    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful.
    /// This method mirrors CSharpFunctionalExtensions naming and delegates to FluentResults semantics.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="isFailure">The condition that determines whether the Result is failed.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A failed Result when <paramref name="isFailure"/> is true; otherwise a successful Result.</returns>
    public static Result<TValue> FailureIf<TValue>(bool isFailure, TValue value, string error) =>
        SuccessIf(!isFailure, value, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using a rich error object.
    /// </summary>
    public static Result<TValue> FailureIf<TValue>(bool isFailure, TValue value, IError error) =>
        SuccessIf(!isFailure, value, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using rich error objects.
    /// </summary>
    public static Result<TValue> FailureIf<TValue>(bool isFailure, TValue value, IEnumerable<IError> errors) =>
        SuccessIf(!isFailure, value, errors);

    /// <summary>
    /// Returns a Result that is failed when the predicate evaluates to true, otherwise successful.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="failurePredicate">Predicate that determines whether the Result is failed.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A failed Result when the predicate evaluates to true; otherwise a successful Result.</returns>
    public static Result<TValue> FailureIf<TValue>(Func<bool> failurePredicate, TValue value, string error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailureIf(failurePredicate(), value, error);
    }
    /// <summary>
    /// Returns a Result that is failed when the predicate evaluates to true, otherwise successful, using a rich error object.
    /// </summary>
    public static Result<TValue> FailureIf<TValue>(Func<bool> failurePredicate, TValue value, IError error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailureIf(failurePredicate(), value, error);
    }
    /// <summary>
    /// Returns a Result that is failed when the predicate evaluates to true, otherwise successful, using rich error objects.
    /// </summary>
    public static Result<TValue> FailureIf<TValue>(Func<bool> failurePredicate, TValue value, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailureIf(failurePredicate(), value, errors);
    }

    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful.
    /// This method is asynchronous for API consistency with async code paths.
    /// </summary>
    /// <param name="isFailure">The condition that determines whether the Result is failed.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static ValueTask<Result> FailureIfAsync(bool isFailure, string error) =>
        SuccessIfAsync(!isFailure, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using a rich error object.
    /// </summary>
    public static ValueTask<Result> FailureIfAsync(bool isFailure, IError error) =>
        SuccessIfAsync(!isFailure, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using rich error objects.
    /// </summary>
    public static ValueTask<Result> FailureIfAsync(bool isFailure, IEnumerable<IError> errors) =>
        SuccessIfAsync(!isFailure, errors);

    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful.
    /// This method is asynchronous for API consistency with async code paths.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="isFailure">The condition that determines whether the Result is failed.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static ValueTask<Result<TValue>> FailureIfAsync<TValue>(bool isFailure, TValue value, string error) =>
        SuccessIfAsync(!isFailure, value, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using a rich error object.
    /// </summary>
    public static ValueTask<Result<TValue>> FailureIfAsync<TValue>(bool isFailure, TValue value, IError error) =>
        SuccessIfAsync(!isFailure, value, error);
    /// <summary>
    /// Returns a Result that is failed if the specified condition is true, otherwise successful, using rich error objects.
    /// </summary>
    public static ValueTask<Result<TValue>> FailureIfAsync<TValue>(bool isFailure, TValue value, IEnumerable<IError> errors) =>
        SuccessIfAsync(!isFailure, value, errors);

    /// <summary>
    /// Returns a Result that is failed when the Task predicate evaluates to true, otherwise successful.
    /// </summary>
    /// <param name="failurePredicate">Asynchronous predicate that determines whether the Result is failed.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result> FailureIfAsync(Func<Task<bool>> failurePredicate, string error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), error);
    }
    /// <summary>
    /// Returns a Result that is failed when the Task predicate evaluates to true, otherwise successful, using a rich error object.
    /// </summary>
    public static async ValueTask<Result> FailureIfAsync(Func<Task<bool>> failurePredicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), error);
    }
    /// <summary>
    /// Returns a Result that is failed when the Task predicate evaluates to true, otherwise successful, using rich error objects.
    /// </summary>
    public static async ValueTask<Result> FailureIfAsync(Func<Task<bool>> failurePredicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), errors);
    }

    /// <summary>
    /// Returns a Result that is failed when the Task predicate evaluates to true, otherwise successful.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="failurePredicate">Asynchronous predicate that determines whether the Result is failed.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result<TValue>> FailureIfAsync<TValue>(Func<Task<bool>> failurePredicate, TValue value, string error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), value, error);
    }
    /// <summary>
    /// Returns a Result that is failed when the Task predicate evaluates to true, otherwise successful, using a rich error object.
    /// </summary>
    public static async ValueTask<Result<TValue>> FailureIfAsync<TValue>(Func<Task<bool>> failurePredicate, TValue value, IError error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), value, error);
    }
    /// <summary>
    /// Returns a Result that is failed when the Task predicate evaluates to true, otherwise successful, using rich error objects.
    /// </summary>
    public static async ValueTask<Result<TValue>> FailureIfAsync<TValue>(Func<Task<bool>> failurePredicate, TValue value, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), value, errors);
    }

    /// <summary>
    /// Returns a Result that is failed when the ValueTask predicate evaluates to true, otherwise successful.
    /// </summary>
    /// <param name="failurePredicate">Asynchronous predicate that determines whether the Result is failed.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result> FailureIfAsync(Func<ValueTask<bool>> failurePredicate, string error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), error);
    }
    /// <summary>
    /// Returns a Result that is failed when the ValueTask predicate evaluates to true, otherwise successful, using a rich error object.
    /// </summary>
    public static async ValueTask<Result> FailureIfAsync(Func<ValueTask<bool>> failurePredicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), error);
    }
    /// <summary>
    /// Returns a Result that is failed when the ValueTask predicate evaluates to true, otherwise successful, using rich error objects.
    /// </summary>
    public static async ValueTask<Result> FailureIfAsync(Func<ValueTask<bool>> failurePredicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), errors);
    }

    /// <summary>
    /// Returns a Result that is failed when the ValueTask predicate evaluates to true, otherwise successful.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="failurePredicate">Asynchronous predicate that determines whether the Result is failed.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result<TValue>> FailureIfAsync<TValue>(Func<ValueTask<bool>> failurePredicate, TValue value, string error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), value, error);
    }
    /// <summary>
    /// Returns a Result that is failed when the ValueTask predicate evaluates to true, otherwise successful, using a rich error object.
    /// </summary>
    public static async ValueTask<Result<TValue>> FailureIfAsync<TValue>(Func<ValueTask<bool>> failurePredicate, TValue value, IError error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), value, error);
    }
    /// <summary>
    /// Returns a Result that is failed when the ValueTask predicate evaluates to true, otherwise successful, using rich error objects.
    /// </summary>
    public static async ValueTask<Result<TValue>> FailureIfAsync<TValue>(Func<ValueTask<bool>> failurePredicate, TValue value, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return await FailureIfAsync(await failurePredicate(), value, errors);
    }
}
