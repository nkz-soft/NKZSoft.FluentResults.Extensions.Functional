namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class FinallyTestsValueTaskRight : FinallyTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultReturnsT(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.FinallyAsync(ValueTaskTValueResultFuncAsync);

        AssertCalled(result, output);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.FinallyAsync(ValueTaskTValueResultTFuncAsync);

        AssertCalled(result, output);
    }
}
