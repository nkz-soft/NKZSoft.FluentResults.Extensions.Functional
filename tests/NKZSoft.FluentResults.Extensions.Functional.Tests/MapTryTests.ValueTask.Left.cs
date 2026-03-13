namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTryTestsValueTaskLeft : MapTryTestsBase
{
    [Test]
    public async Task MapTryAsyncValueTaskLeftReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().MapTryAsync(MapFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskLeftSelectsNewResult()
    {
        var output = await ValueTaskOkResultAsync().MapTryAsync(MapFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskLeftConvertsExceptionToFailureWithDefaultError()
    {
        var output = await ValueTaskOkResultAsync().MapTryAsync(ThrowMapFunc);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskLeftConvertsExceptionToFailureWithCustomError()
    {
        var output = await ValueTaskOkResultAsync().MapTryAsync(ThrowMapFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskLeftTSelectsNewResult()
    {
        var output = await ValueTaskOkResultTAsync().MapTryAsync(MapFunc);

        AssertSuccess(output);
    }

    [Test]
    public async Task MapTryAsyncValueTaskLeftTConvertsExceptionToFailureWithCustomError()
    {
        var output = await ValueTaskOkResultTAsync().MapTryAsync(ThrowMapFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }
}
