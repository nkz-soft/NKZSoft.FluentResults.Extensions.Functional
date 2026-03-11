namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class SelectTestsTaskLeft : SelectTestsBase
{
    [Test]
    public async Task SelectTaskLeftReturnsFailureAndDoesNotExecuteSelector()
    {
        var output = await TaskFailResultAsync().SelectAsync(SelectFunc);
        AssertFailure(output);
    }

    [Test]
    public async Task SelectTaskLeftProjectsNewResult()
    {
        var output = await TaskOkResultAsync().SelectAsync(SelectFunc);
        AssertSuccess(output);
    }

    [Test]
    public async Task SelectTaskLeftTReturnsFailureAndDoesNotExecuteSelector()
    {
        var output = await TaskFailResultTAsync().SelectAsync(SelectFunc);
        AssertFailure(output);
    }

    [Test]
    public async Task SelectTaskLeftTProjectsNewResult()
    {
        var output = await TaskOkResultTAsync().SelectAsync(SelectFunc);
        AssertSuccess(output);
    }
}
