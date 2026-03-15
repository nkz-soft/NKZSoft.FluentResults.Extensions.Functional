namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTryTestsTaskRight : BindTryTestsBase
{
    [Test]
    public async Task BindTryAsyncTaskRightReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindTryAsync(TaskOkResultFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindTryAsyncTaskRightSelectsNewTypedResult()
    {
        var output = await Result.Ok().BindTryAsync(TaskOkResultTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncTaskRightConvertsExceptionToFailureWithDefaultError()
    {
        var output = await Result.Ok().BindTryAsync(ThrowTaskResultFuncAsync);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task BindTryAsyncTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).BindTryAsync(TaskOkResultFromTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncTaskRightTConvertsExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok(TValue.Value).BindTryAsync(ThrowTaskResultTFromTFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
