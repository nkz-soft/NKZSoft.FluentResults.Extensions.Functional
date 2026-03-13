namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTryTestsValueTaskRight : MapTryTestsBase
{
    [Test]
    public async Task MapTryAsyncValueTaskRightReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await Result.Fail(ErrorMessage).MapTryAsync(ValueTaskMapFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskRightSelectsNewResult()
    {
        var output = await Result.Ok().MapTryAsync(ValueTaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskRightConvertsExceptionToFailureWithDefaultError()
    {
        var output = await Result.Ok().MapTryAsync(ThrowValueTaskMapFuncAsync);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskRightConvertsExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok().MapTryAsync(ThrowValueTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskRightTSelectsNewResult()
    {
        var output = await Result.Ok(TValue.Value).MapTryAsync(ValueTaskMapFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskRightTConvertsExceptionToFailureWithCustomError()
    {
        var output = await Result.Ok(TValue.Value).MapTryAsync(ThrowValueTaskMapFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
