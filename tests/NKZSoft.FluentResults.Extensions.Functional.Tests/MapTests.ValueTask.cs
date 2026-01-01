namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTestsValueTask : MapTestsBase
{
    [Fact]
    public async Task MapValueTaskReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapValueTaskSelectsNewResult()
    {
        var output = await Common.TestBase.ValueTaskOkResultAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task MapValueTaskTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapValueTaskTSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }
}
