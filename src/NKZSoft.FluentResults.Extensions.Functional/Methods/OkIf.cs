namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns a Result that is successful if the specified condition is true, otherwise failed.
    /// This method mirrors CSharpFunctionalExtensions naming and delegates to FluentResults semantics.
    /// </summary>
    /// <param name="isSuccess">The condition that determines whether the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A successful Result when <paramref name="isSuccess"/> is true; otherwise a failed Result.</returns>
    public static Result SuccessIf(bool isSuccess, string error) =>
        isSuccess ? Result.Ok() : Result.Fail(error);

    /// <summary>
    /// Returns a Result that is successful when the predicate evaluates to true, otherwise failed.
    /// </summary>
    /// <param name="predicate">Predicate that determines whether the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A successful Result when the predicate evaluates to true; otherwise a failed Result.</returns>
    public static Result SuccessIf(Func<bool> predicate, string error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return SuccessIf(predicate(), error);
    }

    /// <summary>
    /// Returns a Result that is successful if the specified condition is true, otherwise failed.
    /// This method mirrors CSharpFunctionalExtensions naming and delegates to FluentResults semantics.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="isSuccess">The condition that determines whether the Result is successful.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A successful Result when <paramref name="isSuccess"/> is true; otherwise a failed Result.</returns>
    public static Result<TValue> SuccessIf<TValue>(bool isSuccess, TValue value, string error) =>
        OkIf(isSuccess, error, value);

    /// <summary>
    /// Returns a Result that is successful when the predicate evaluates to true, otherwise failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="predicate">Predicate that determines whether the Result is successful.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A successful Result when the predicate evaluates to true; otherwise a failed Result.</returns>
    public static Result<TValue> SuccessIf<TValue>(Func<bool> predicate, TValue value, string error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return SuccessIf(predicate(), value, error);
    }

    /// <summary>
    /// Returns a Result that is Ok if the specified condition is true, otherwise Fail.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="isSuccess">The condition that determines whether the Result is Ok or Fail.</param>
    /// <param name="error">The error message to use if the Result is Fail.</param>
    /// <param name="value">The value to use if the Result is Ok.</param>
    /// <returns>A Result that is Ok if isSuccess is true, otherwise Fail.</returns>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, string error, TValue value) =>
        isSuccess ? Result.Ok(value) : Result.Fail<TValue>(error);

    /// <summary>
    /// Returns a Result that is Ok if the specified condition is true, otherwise Fail.
    /// This method is asynchronous, but it does not actually perform any asynchronous operations.
    /// It is intended to be used in asynchronous code paths where a Result needs to be returned.
    /// </summary>
    /// <param name="isSuccess">The condition that determines whether the Result is Ok or Fail.</param>
    /// <param name="error">The error message to use if the Result is Fail.</param>
    /// <returns>A Task that contains a Result that is Ok if isSuccess is true, otherwise Fail.</returns>
    public static ValueTask<Result> OkIfAsync(bool isSuccess, string error) =>
        ValueTask.FromResult(isSuccess ? Result.Ok() : Result.Fail(error));

    /// <summary>
    /// Returns a Result that is Ok if the specified condition is true, otherwise Fail.
    /// This method is asynchronous, but it does not actually perform any asynchronous operations.
    /// It is intended to be used in asynchronous code paths where a Result needs to be returned.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="isSuccess">The condition that determines whether the Result is Ok or Fail.</param>
    /// <param name="error">The error message to use if the Result is Fail.</param>
    /// <param name="value">The value to use if the Result is Ok.</param>
    /// <returns>A Task that contains a Result that is Ok if isSuccess is true, otherwise Fail.</returns>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(bool isSuccess, string error, TValue value) =>
        ValueTask.FromResult(isSuccess ? Result.Ok(value) : Result.Fail<TValue>(error));

    /// <summary>
    /// Returns a Result that is successful if the specified condition is true, otherwise failed.
    /// This method is asynchronous for API consistency with async code paths.
    /// </summary>
    /// <param name="isSuccess">The condition that determines whether the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static ValueTask<Result> SuccessIfAsync(bool isSuccess, string error) =>
        OkIfAsync(isSuccess, error);

    /// <summary>
    /// Returns a Result that is successful if the specified condition is true, otherwise failed.
    /// This method is asynchronous for API consistency with async code paths.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="isSuccess">The condition that determines whether the Result is successful.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static ValueTask<Result<TValue>> SuccessIfAsync<TValue>(bool isSuccess, TValue value, string error) =>
        OkIfAsync(isSuccess, error, value);

    /// <summary>
    /// Returns a Result that is successful when the Task predicate evaluates to true, otherwise failed.
    /// </summary>
    /// <param name="predicate">Asynchronous predicate that determines whether the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result> SuccessIfAsync(Func<Task<bool>> predicate, string error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await SuccessIfAsync(await predicate(), error);
    }

    /// <summary>
    /// Returns a Result that is successful when the Task predicate evaluates to true, otherwise failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="predicate">Asynchronous predicate that determines whether the Result is successful.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result<TValue>> SuccessIfAsync<TValue>(Func<Task<bool>> predicate, TValue value, string error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await SuccessIfAsync(await predicate(), value, error);
    }

    /// <summary>
    /// Returns a Result that is successful when the ValueTask predicate evaluates to true, otherwise failed.
    /// </summary>
    /// <param name="predicate">Asynchronous predicate that determines whether the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result> SuccessIfAsync(Func<ValueTask<bool>> predicate, string error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await SuccessIfAsync(await predicate(), error);
    }

    /// <summary>
    /// Returns a Result that is successful when the ValueTask predicate evaluates to true, otherwise failed.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="predicate">Asynchronous predicate that determines whether the Result is successful.</param>
    /// <param name="value">The value to use when the Result is successful.</param>
    /// <param name="error">The error message to use when the Result is failed.</param>
    /// <returns>A ValueTask that contains the resulting Result.</returns>
    public static async ValueTask<Result<TValue>> SuccessIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue value, string error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await SuccessIfAsync(await predicate(), value, error);
    }
}
