namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MatchTestsTaskLeft : MatchTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResult(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(SuccessEmpty, Failure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultReturnsValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(ValueSuccess, ValueFailure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(SuccessT, Failure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(ValueSuccessT, ValueFailure);

        AssertSuccess(isSuccess);
    }
}
