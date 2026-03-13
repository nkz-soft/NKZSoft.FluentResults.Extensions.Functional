namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps all errors of a failed result and returns successful results unchanged.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="errorMapper">The error mapping function.</param>
    /// <returns>The original successful result or a failed result with mapped errors.</returns>
    public static Result MapError(this Result result, Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        return result.MapErrors(errorMapper);
    }

    /// <summary>
    /// Maps all errors of a failed result and returns successful results unchanged.
    /// </summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="errorMapper">The error mapping function.</param>
    /// <returns>The original successful result or a failed result with mapped errors.</returns>
    public static Result<TValue> MapError<TValue>(this Result<TValue> result, Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        return result.MapErrors(errorMapper);
    }

    internal static async ValueTask<Result> InternalMapErrorAsync(
        this Result result,
        Func<IError, ValueTask<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        if (result.IsSuccess)
        {
            return result;
        }

        var mappedErrors = await MapErrorsAsync(result.Errors, errorMapper).ConfigureAwait(false);
        return new Result()
            .WithErrors(mappedErrors)
            .WithSuccesses(result.Successes);
    }

    internal static async ValueTask<Result<TValue>> InternalMapErrorAsync<TValue>(
        this Result<TValue> result,
        Func<IError, ValueTask<IError>> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);

        if (result.IsSuccess)
        {
            return result;
        }

        var mappedErrors = await MapErrorsAsync(result.Errors, errorMapper).ConfigureAwait(false);
        return new Result<TValue>()
            .WithErrors(mappedErrors)
            .WithSuccesses(result.Successes);
    }

    private static async Task<List<IError>> MapErrorsAsync(
        IEnumerable<IError> errors,
        Func<IError, ValueTask<IError>> errorMapper)
    {
        var mappedErrors = new List<IError>();

        foreach (var error in errors)
        {
            mappedErrors.Add(await errorMapper(error).ConfigureAwait(false));
        }

        return mappedErrors;
    }
}
