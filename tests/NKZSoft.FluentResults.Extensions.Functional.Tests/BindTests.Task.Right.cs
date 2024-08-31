namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsTaskRight : BindTestsBase
{
    [Fact]
    public async Task BindTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(TaskSuccess);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightSelectsNewResult()
    {
        var output = await Success().BindAsync(TaskSuccess);
        AssertSuccess(output);
    }

    [Fact]
    public async Task BindTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail<string>(ErrorMessage).BindAsync(TaskSuccessT);
        AssertFailure(output);
    }

    [Fact]
    public async Task BindTaskRightTSelectsNewResult()
    {
        var output = await SuccessT(Value).BindAsync(TaskSuccessT);
        AssertSuccess(output);
    }
}
