namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsValueTaskRight : BindTestsBase
{
    [Fact]
    public async Task BindTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(ValueTaskOkFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().BindAsync(ValueTaskOkFuncAsync);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(ValueTaskOkFuncAsync);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).BindAsync(ValueTaskOkTFuncAsync);
        AssertSuccess(output);
    }
}
