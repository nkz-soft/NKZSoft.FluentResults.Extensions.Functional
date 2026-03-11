namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsTaskRight : BindTestsBase
{
    [Test]
    public async Task BindTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(TaskOkFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().BindAsync(TaskOkFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task BindTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).BindAsync(TaskOkTFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).BindAsync(TaskOkTFuncAsync);
        AssertSuccess(output);
    }
}
