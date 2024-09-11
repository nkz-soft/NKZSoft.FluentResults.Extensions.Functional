namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MatchTests : MatchTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MatchResult(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        result.Match(SuccessEmpty, Failure);

        AssertSuccess(result, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MatchResultReturnsValue(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        result.Match(ValueSuccess, ValueFailure);

        AssertSuccess(result, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        result.Match(SuccessT, Failure);

        AssertSuccess(result, isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        result.Match(ValueSuccessT, ValueFailure);

        AssertSuccess(result, isSuccess);
    }
}
