namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
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
}
