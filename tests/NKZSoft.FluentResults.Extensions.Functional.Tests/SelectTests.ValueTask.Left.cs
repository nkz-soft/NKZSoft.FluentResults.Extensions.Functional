namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class SelectTestsValueTaskLeft : SelectTestsBase
{
    [Fact]
    public async Task SelectValueTaskLeftReturnsFailureAndDoesNotExecuteSelector()
    {
        var output = await ValueTaskFailResultAsync().SelectAsync(SelectFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task SelectValueTaskLeftProjectsNewResult()
    {
        var output = await ValueTaskOkResultAsync().SelectAsync(SelectFunc);
        AssertSuccess(output);
    }

    [Fact]
    public async Task SelectValueTaskLeftTReturnsFailureAndDoesNotExecuteSelector()
    {
        var output = await ValueTaskFailResultTAsync().SelectAsync(SelectFunc);
        AssertFailure(output);
    }

    [Fact]
    public async Task SelectValueTaskLeftTProjectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().SelectAsync(SelectFunc);
        AssertSuccess(output);
    }
}
