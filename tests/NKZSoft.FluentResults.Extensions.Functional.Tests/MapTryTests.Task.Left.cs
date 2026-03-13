namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTryTestsTaskLeft : MapTryTestsBase
{
    [Test]
    public async Task MapTryAsyncTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await TaskFailResultAsync().MapTryAsync(MapFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskLeftSelectsNewResult()
    {
        var output = await TaskOkResultAsync().MapTryAsync(MapFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncTaskLeftConvertsExceptionToFailureWithDefaultError()
    {
        var output = await TaskOkResultAsync().MapTryAsync(ThrowMapFunc);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskLeftConvertsExceptionToFailureWithCustomError()
    {
        var output = await TaskOkResultAsync().MapTryAsync(ThrowMapFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task MapTryAsyncTaskLeftTSelectsNewResult()
    {
        var output = await TaskOkResultTAsync().MapTryAsync(MapFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncTaskLeftTConvertsExceptionToFailureWithCustomError()
    {
        var output = await TaskOkResultTAsync().MapTryAsync(ThrowMapFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
