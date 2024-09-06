namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class FinallyTestsTask : FinallyTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultReturnsT(bool isSuccess)
    {
        var result =  ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        var output = await result.FinallyAsync(TaskTValueResultFuncAsync);

        AssertCalled(output);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        var output = await result.FinallyAsync(TaskFuncResultTAsync);

        AssertCalled(output);
    }
}
