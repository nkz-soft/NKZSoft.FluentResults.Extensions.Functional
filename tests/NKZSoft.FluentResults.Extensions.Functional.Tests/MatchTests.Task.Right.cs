namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MatchTestsTaskRight : MatchTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResult(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        await result.MatchAsync(SuccessEmptyAsync, FailureAsync);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultReturnsValue(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        await result.MatchAsync(ValueSuccessAsync, ValueFailureAsync);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        await result.MatchAsync(ValueSuccessAsync, FailureAsync);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        await result.MatchAsync(ValueSuccessTAsync, ValueFailureTAsync);

        AssertSuccess(result, isSuccess);
    }
}
