namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MapTestsValueTaskLeft : MapTestsBase
{
    [Fact]
    public async Task MapValueTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().MapAsync(MapFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapValueTaskLeftSelectsNewResult()
    {
        var output = await Common.TestBase.ValueTaskOkResultAsync().MapAsync(MapFunc);
        AssertSuccess(output);
    }

    [Fact]
    public async Task MapValueTaskLeftTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultTAsync().MapAsync(MapFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapValueTaskLeftTSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().MapAsync(MapFunc);
        AssertSuccess(output);
    }
}
