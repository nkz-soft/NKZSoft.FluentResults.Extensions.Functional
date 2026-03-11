namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnFailureCompensateTestsValueTask : CompensateTestsBase
{
    [Fact]
    public async Task OnFailureCompensateAsyncExecutesValueTaskFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result>(Result.Fail(ErrorMessage))
            .OnFailureCompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task OnFailureCompensateAsyncExecutesTaskFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result>(Result.Fail(ErrorMessage))
            .OnFailureCompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task OnFailureCompensateAsyncTExecutesValueTaskFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Fail<TValue>(ErrorMessage))
            .OnFailureCompensateAsync(() => ValueTaskOkCompensateTAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }
}
