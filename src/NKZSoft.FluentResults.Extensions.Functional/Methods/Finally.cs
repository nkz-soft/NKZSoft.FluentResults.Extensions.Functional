﻿namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <param name="result">The Result to execute the function after.</param>
    /// <param name="func">The function to execute after the Result.</param>
    /// <returns>The result of the executed function.</returns>
    public static T Finally<T>(this Result result, Func<Result, T> func)
        => func(result);

    /// <summary>
    /// Executes a function after a Result, regardless of its success or failure.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the function.</typeparam>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The Result to execute the function after.</param>
    /// <param name="func">The function to execute after the Result.</param>
    /// <returns>The result of the executed function.</returns>
    public static T Finally<T, TValue>(this Result<TValue> result, Func<Result<TValue>, T> func)
        => func(result);
}