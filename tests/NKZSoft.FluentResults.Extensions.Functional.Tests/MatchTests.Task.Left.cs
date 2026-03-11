namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MatchTestsTaskLeft : MatchTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResult(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(SuccessEmpty, Failure);

        AssertSuccess(isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResultReturnsValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(ValueSuccess, ValueFailure);

        AssertSuccess(isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(SuccessT, Failure);

        AssertSuccess(isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(ValueSuccessT, ValueFailure);

        AssertSuccess(isSuccess);
    }
}
