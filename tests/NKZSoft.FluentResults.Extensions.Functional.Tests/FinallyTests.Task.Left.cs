namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FinallyTestsTaskLeft : FinallyTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.FinallyAsync(TValueResultFunc);

        AssertCalled(output);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.FinallyAsync(TValueResultTFunc);

        AssertCalled(output);
    }
}
