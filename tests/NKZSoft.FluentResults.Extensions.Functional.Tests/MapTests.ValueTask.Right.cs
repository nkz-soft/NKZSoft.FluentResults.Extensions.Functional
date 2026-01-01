namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MapTestsValueTaskRight : MapTestsBase
{
    [Fact]
    public async Task MapValueTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapValueTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task MapValueTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).MapAsync(ValueTaskMapFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task MapValueTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).MapAsync(ValueTaskMapFuncAsync);
        AssertSuccess(output);
    }
}
