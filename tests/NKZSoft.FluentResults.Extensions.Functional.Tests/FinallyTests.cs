namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FinallyTests : FinallyTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void FinallyResultReturnsT(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = result.Finally(TValueResultFunc);

        AssertCalled(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public void FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = result.Finally(TValueResultTFunc);

        AssertCalled(result, output);
    }
}
