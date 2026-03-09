namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the first failed result from the supplied asynchronous results.
    /// If there is no failed result, returns a successful result.
    /// </summary>
    /// <param name="results">The task-based results to inspect.</param>
    /// <returns>The first failed result, or a successful result when all inputs are successful.</returns>
    public static async Task<Result> FirstFailureOrSuccessAsync(params Task<Result>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);

        foreach (var resultTask in results)
        {
            ArgumentNullException.ThrowIfNull(resultTask);

            var result = await resultTask.ConfigureAwait(false);
            if (result.IsFailed)
            {
                return result;
            }
        }

        return Result.Ok();
    }
}
