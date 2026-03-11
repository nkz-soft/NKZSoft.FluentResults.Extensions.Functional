namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTestsValueTaskRight : BindTestsBase
{
    [Test]
    public async Task BindTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(ValueTaskOkFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().BindAsync(ValueTaskOkFuncAsync);
        AssertSuccess(output);
    }

    [Test]
    public async Task BindTaskRightTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindAsync(ValueTaskOkFuncAsync);
        AssertFailure(output);
    }

    [Test]
    public async Task BindTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).BindAsync(ValueTaskOkTFuncAsync);
        AssertSuccess(output);
    }
}
