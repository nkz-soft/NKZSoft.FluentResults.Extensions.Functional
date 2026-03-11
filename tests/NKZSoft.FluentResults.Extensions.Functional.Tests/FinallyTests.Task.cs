namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FinallyTestsTask : FinallyTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task FinallyResultReturnsT(bool isSuccess)
    {
        var result =  ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.FinallyAsync(TaskTValueResultFuncAsync);

        AssertCalled(output);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.FinallyAsync(TaskFuncResultTAsync);

        AssertCalled(output);
    }
}
