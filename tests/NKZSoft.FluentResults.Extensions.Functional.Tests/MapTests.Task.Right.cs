namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MapTestsTaskRight : MapTestsBase
{
    [Fact]
    public async Task MapTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task MapTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).MapAsync(TaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).MapAsync(TaskMapFuncAsync);
        AssertSuccess(output);
    }
}
