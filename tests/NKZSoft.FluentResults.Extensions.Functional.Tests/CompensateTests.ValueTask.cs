namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompensateTestsValueTask : CompensateTestsBase
{
    [Fact]
    public async Task CompensateAsyncExecutesValueTaskFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result>(Result.Fail(ErrorMessage))
            .CompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CompensateAsyncExecutesTaskFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result>(Result.Fail(ErrorMessage))
            .CompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CompensateAsyncWithErrorsValueTaskFallbackPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await new ValueTask<Result>(result).CompensateAsync(errors => ValueTaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Fact]
    public async Task CompensateAsyncWithErrorsTaskFallbackPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await new ValueTask<Result>(result).CompensateAsync(errors => TaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Fact]
    public async Task CompensateAsyncTExecutesValueTaskFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Fail<TValue>(ErrorMessage))
            .CompensateAsync(() => ValueTaskOkCompensateTAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task CompensateAsyncTExecutesTaskFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result<TValue>>(Result.Fail<TValue>(ErrorMessage))
            .CompensateAsync(() => TaskOkCompensateTAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }
}
