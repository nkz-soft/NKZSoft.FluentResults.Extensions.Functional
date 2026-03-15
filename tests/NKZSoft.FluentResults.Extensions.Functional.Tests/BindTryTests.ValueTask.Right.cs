namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTryTestsValueTaskRight : BindTryTestsBase
{
    [Test]
    public async Task BindTryAsyncValueTaskRightReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).BindTryAsync(ValueTaskOkResultFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskRightSelectsNewTypedResult()
    {
        var output = await Result.Ok().BindTryAsync(ValueTaskOkResultTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskRightConvertsExceptionToFailureWithDefaultError()
    {
        var output = await Result.Ok().BindTryAsync(ThrowValueTaskResultFuncAsync);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).BindTryAsync(ValueTaskOkResultFromTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskRightTConvertsExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok(TValue.Value).BindTryAsync(ThrowValueTaskResultTFromTFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
