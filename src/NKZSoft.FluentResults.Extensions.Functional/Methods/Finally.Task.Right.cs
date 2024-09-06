namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure,
    /// and returns the result of the executed function as a Task.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <param name="result">The Result to execute the function after.</param>
    /// <param name="func">The function to execute after the Result. This function takes the Result as an argument and returns a Task.</param>
    /// <returns>A Task that represents the result of the executed function.</returns>
    public static Task<T> FinallyAsync<T>(this Result result, Func<Result, Task<T>> func) =>
        func(result);

    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure,
    /// and returns the result of the executed function as a Task.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The Result to execute the function after.</param>
    /// <param name="func">The function to execute after the Result. This function takes the Result as an argument and returns a Task.</param>
    /// <returns>A Task that represents the result of the executed function.</returns>
    public static Task<T> FinallyAsync<T, TValue>(this Result<TValue> result,
        Func<Result<TValue>, Task<T>> func) =>
        func(result);
}
