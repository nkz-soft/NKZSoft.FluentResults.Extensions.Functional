namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnFailureCompensateTestsTask : CompensateTestsBase
{
    [Test]
    public async Task OnFailureCompensateAsyncExecutesTaskFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail(ErrorMessage))
            .OnFailureCompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task OnFailureCompensateAsyncExecutesValueTaskFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail(ErrorMessage))
            .OnFailureCompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task OnFailureCompensateAsyncTExecutesTaskFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail<TValue>(ErrorMessage))
            .OnFailureCompensateAsync(() => TaskOkCompensateTAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }
}
