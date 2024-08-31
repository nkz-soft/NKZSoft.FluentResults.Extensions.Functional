namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsValueTaskRight : BindTestsBase
{
    [Fact]
    public async Task BindTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(ValueTaskSuccess);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightSelectsNewResult()
    {
        var output = await Success().BindAsync(ValueTaskSuccess);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail<string>(ErrorMessage).BindAsync(ValueTaskSuccessT);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightTSelectsNewResult()
    {
        var output = await SuccessT(Value).BindAsync(ValueTaskSuccessT);
        AssertSuccess(output);
    }
}
