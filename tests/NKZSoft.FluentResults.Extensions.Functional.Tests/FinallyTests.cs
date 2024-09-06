namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class FinallyTests : FinallyTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void FinallyResultReturnsT(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = result.Finally(TValueResultFunc);

        AssertCalled(result, output);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = result.Finally(TValueResultTFunc);

        AssertCalled(result, output);
    }
}
