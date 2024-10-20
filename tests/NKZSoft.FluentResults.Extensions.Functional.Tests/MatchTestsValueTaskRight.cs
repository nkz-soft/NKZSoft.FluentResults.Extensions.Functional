namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MatchTestsValueTaskRight : MatchTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResult(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        await result.MatchAsync(ValueTaskSuccessEmpty, ValueTaskFailure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultReturnsValue(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        await result.MatchAsync(ValueTaskValueSuccess, ValueTaskValueFailure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        await result.MatchAsync(ValueTaskValueSuccess, ValueTaskFailure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        await result.MatchAsync(ValueTaskValueSuccessT, ValueTaskValueFailureT);

        AssertSuccess(result, isSuccess);
    }
}
