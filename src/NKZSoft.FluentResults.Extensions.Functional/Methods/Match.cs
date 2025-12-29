namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Matches a Result to either a success or failure action.
    /// </summary>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The action to execute if the Result is successful.</param>
    /// <param name="onFailure">The action to execute if the Result is failed.</param>
    public static void Match(this Result result, Action onSuccess, Action<IReadOnlyList<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        if (result.IsSuccess)
        {
            onSuccess();
        }
        else
        {
            onFailure(result.Errors);
        }
    }

    /// <summary>
    /// Matches a Result to either a success or failure function.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the functions.</typeparam>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>The result of the executed function.</returns>
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<IReadOnlyList<IError>, T> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        return result.IsSuccess
            ? onSuccess()
            : onFailure(result.Errors);
    }

    /// <summary>
    /// Matches a Result to either a success or failure action.
    /// </summary>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The action to execute if the Result is successful.</param>
    /// <param name="onFailure">The action to execute if the Result is failed.</param>
    public static void Match<TValue>(this Result<TValue> result,
        Action<TValue> onSuccess,
        Action<IReadOnlyList<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        if (result.IsSuccess)
        {
            onSuccess(result.Value);
        }
        else
        {
            onFailure(result.Errors);
        }
    }

    /// <summary>
    /// Matches a Result to either a success or failure function.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by the functions.</typeparam>
    /// <typeparam name="TValue">The type of the value in the result.</typeparam>
    /// <param name="result">The Result to match.</param>
    /// <param name="onSuccess">The function to execute if the Result is successful.</param>
    /// <param name="onFailure">The function to execute if the Result is failed.</param>
    /// <returns>The result of the executed function.</returns>
    public static T Match<T, TValue>(this Result<TValue> result,
        Func<TValue, T> onSuccess,
        Func<IReadOnlyList<IError>, T> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }
}
