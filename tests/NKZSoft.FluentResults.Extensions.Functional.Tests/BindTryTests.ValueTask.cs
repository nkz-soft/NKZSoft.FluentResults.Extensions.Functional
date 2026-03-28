namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTryTestsValueTask : BindTryTestsBase
{
    [Test]
    public async Task BindTryAsyncValueTaskReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = await ValueTaskFailResultAsync().BindTryAsync(ValueTaskOkResultFuncAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskSelectsNewTypedResult()
    {
        var output = await ValueTaskOkResultAsync().BindTryAsync(ValueTaskOkResultTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskConvertsExceptionToFailureWithCustomError()
    {
        var output = await ValueTaskOkResultAsync().BindTryAsync(ThrowValueTaskResultFuncAsync, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskTSelectsNewTypedResult()
    {
        var output = await ValueTaskOkResultTAsync().BindTryAsync(ValueTaskOkResultTFromTFuncAsync);

        AssertSuccess(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskTConvertsExceptionToFailureWithDefaultError()
    {
        var output = await ValueTaskOkResultTAsync().BindTryAsync(ThrowValueTaskResultFromTFuncAsync);

        AssertDefaultFailure(output);
    }

    [Test]
    public async Task BindTryAsyncValueTaskThrowsWhenFuncIsNull()
    {
        Func<ValueTask<Result>> bind = null!;
        var action = async () => await ValueTaskOkResultAsync().BindTryAsync(bind);

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
