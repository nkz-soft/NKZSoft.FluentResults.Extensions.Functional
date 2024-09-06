namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsTaskRight : BindTestsBase
{
    [Fact]
    public async Task BindTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(TaskOkFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().BindAsync(TaskOkFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).BindAsync(TaskOkTFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).BindAsync(TaskOkTFuncAsync);
        AssertSuccess(output);
    }
}
