namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Returns the first failed result from the supplied results.
    /// If there is no failed result, returns a successful result.
    /// </summary>
    /// <param name="results">The results to inspect.</param>
    /// <returns>The first failed result, or a successful result when all inputs are successful.</returns>
    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        ArgumentNullException.ThrowIfNull(results);

        foreach (var result in results)
        {
            ArgumentNullException.ThrowIfNull(result);

            if (result.IsFailed)
            {
                return result;
            }
        }

        return Result.Ok();
    }
}
