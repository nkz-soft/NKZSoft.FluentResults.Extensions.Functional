namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTryTestsTaskRight : MapTryTestsBase
{
    [Test]
    public async Task MapTryAsyncTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).MapTryAsync(TaskMapFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().MapTryAsync(TaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncTaskRightConvertsExceptionToFailureWithDefaultError()
    {
        var output = await Result.Ok().MapTryAsync(ThrowTaskMapFuncAsync);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskRightConvertsExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok().MapTryAsync(ThrowTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).MapTryAsync(TaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncTaskRightTConvertsExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok(TValue.Value).MapTryAsync(ThrowTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
