namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompensateTestsTaskLeft : CompensateTestsBase
{
    [Fact]
    public async Task CompensateAsyncReturnsOriginalTaskResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await Task.FromResult(result).CompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public async Task CompensateAsyncExecutesFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail(ErrorMessage)).CompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await Task.FromResult(result).CompensateAsync(errors => OkCompensate(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Fact]
    public async Task CompensateAsyncTReturnsOriginalTaskResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).CompensateAsync(() => OkCompensateT());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public async Task CompensateAsyncThrowsWhenFallbackIsNull()
    {
        var action = async () => await Task.FromResult(Result.Ok()).CompensateAsync((Func<Result>)null!);
        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
