namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Binds a function to a Result, executing it only if the Result is successful.
    /// </summary>
    /// <param name="result">The Result to bind the function to.</param>
    /// <param name="func">The function to bind to the Result.</param>
    /// <returns>A new Result that is the result of executing the bound function, or the original failed Result if it was failed.</returns>
    internal static Result IternalBind(this Result result, Func<Result> func) =>
        result.IsFailed ? result : func();

    /// <summary>
    /// Binds a function to a Result, executing it only if the Result is successful.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the Result.</typeparam>
    /// <param name="result">The Result to bind the function to.</param>
    /// <param name="func">The function to bind to the Result. This function takes the value from the Result and returns a new Result.</param>
    /// <returns>A new Result that is the result of executing the bound function, or the original failed Result if it was failed.</returns>
    internal static Result<TValue> IternalBind<TValue>(this Result<TValue> result, Func<TValue, Result<TValue>> func) =>
        result.IsFailed ? result : func(result.Value);
}
