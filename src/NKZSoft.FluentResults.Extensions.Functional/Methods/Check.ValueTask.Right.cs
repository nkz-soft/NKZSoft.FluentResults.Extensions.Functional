namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Executes a check if the result is successful.
    /// If the check fails, returns the failed Result.
    /// </summary>
    /// <param name="result">The Result to check.</param>
    /// <param name="check">The check to execute.</param>
    /// <returns>A ValueTask containing the original Result when successful, otherwise the failed check Result.</returns>
    public static async ValueTask<Result> CheckAsync(this Result result, Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        if (result.IsFailed)
        {
            return result;
        }

        var checkResult = await check().ConfigureAwait(false);

        return checkResult.IsFailed ? checkResult : result;
    }

    /// <summary>
    /// Executes a check if the result is successful.
    /// If the check fails, returns a failed Result with the check errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The Result to check.</param>
    /// <param name="check">The check to execute.</param>
    /// <returns>A ValueTask containing the original Result when successful, otherwise a failed Result with the check errors.</returns>
    public static async ValueTask<Result<TValue>> CheckAsync<TValue>(this Result<TValue> result, Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        if (result.IsFailed)
        {
            return result;
        }

        var checkResult = await check().ConfigureAwait(false);

        return checkResult.IsFailed ? Result.Fail<TValue>(checkResult.Errors) : result;
    }

    /// <summary>
    /// Executes a check if the result is successful.
    /// If the check fails, returns a failed Result with the check errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the value contained in the Result.</typeparam>
    /// <param name="result">The Result to check.</param>
    /// <param name="check">The check to execute using the Result value.</param>
    /// <returns>A ValueTask containing the original Result when successful, otherwise a failed Result with the check errors.</returns>
    public static async ValueTask<Result<TValue>> CheckAsync<TValue>(this Result<TValue> result, Func<TValue, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(check);

        if (result.IsFailed)
        {
            return result;
        }

        var checkResult = await check(result.Value).ConfigureAwait(false);

        return checkResult.IsFailed ? Result.Fail<TValue>(checkResult.Errors) : result;
    }
}
