namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FinallyTestsTaskRight : FinallyTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task FinallyResultReturnsT(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        var output = await result.FinallyAsync(TaskTValueResultFuncAsync);

        AssertCalled(result, output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.FinallyAsync(TaskFuncResultTAsync);

        AssertCalled(result, output);
    }
}
