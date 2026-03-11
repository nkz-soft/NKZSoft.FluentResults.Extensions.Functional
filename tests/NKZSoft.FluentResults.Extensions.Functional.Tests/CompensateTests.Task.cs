namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompensateTestsTask : CompensateTestsBase
{
    [Test]
    public async Task CompensateAsyncExecutesTaskFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail(ErrorMessage))
            .CompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompensateAsyncExecutesValueTaskFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail(ErrorMessage))
            .CompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompensateAsyncWithErrorsTaskFallbackPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await Task.FromResult(result).CompensateAsync(errors => TaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Test]
    public async Task CompensateAsyncWithErrorsValueTaskFallbackPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await Task.FromResult(result).CompensateAsync(errors => ValueTaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Test]
    public async Task CompensateAsyncTExecutesTaskFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail<TValue>(ErrorMessage))
            .CompensateAsync(() => TaskOkCompensateTAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task CompensateAsyncTExecutesValueTaskFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail<TValue>(ErrorMessage))
            .CompensateAsync(() => ValueTaskOkCompensateTAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }
}
