namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MapTestsTaskLeft : MapTestsBase
{
    [Test]
    public async Task MapTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().MapAsync(MapFunc);
        AssertFailure(output);
    }

    [Test]
    public async Task MapTaskLeftSelectsNewResult()
    {
        var output = await Common.TestBase.TaskOkResultAsync().MapAsync(MapFunc);
        AssertSuccess(output);
    }

    [Test]
    public async Task MapTaskLeftTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultTAsync().MapAsync(MapFunc);
        AssertFailure(output);
    }

    [Test]
    public async Task MapTaskLeftTSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().MapAsync(MapFunc);
        AssertSuccess(output);
    }
}
