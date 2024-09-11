namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MatchTestsTask : MatchTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResult(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(SuccessEmptyAsync, FailureAsync);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultReturnsValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(ValueSuccessAsync, ValueFailureAsync);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(ValueSuccessAsync, FailureAsync);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(ValueSuccessTAsync, ValueFailureTAsync);

        AssertSuccess(isSuccess);
    }
}
