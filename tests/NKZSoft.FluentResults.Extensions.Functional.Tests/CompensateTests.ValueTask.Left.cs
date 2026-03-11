namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompensateTestsValueTaskLeft : CompensateTestsBase
{
    [Test]
    public async Task CompensateAsyncReturnsOriginalValueTaskResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).CompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task CompensateAsyncExecutesFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result>(Result.Fail(ErrorMessage)).CompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await new ValueTask<Result>(result).CompensateAsync(errors => OkCompensate(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Test]
    public async Task CompensateAsyncTReturnsOriginalValueTaskResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).CompensateAsync(() => OkCompensateT());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task CompensateAsyncThrowsWhenFallbackIsNull()
    {
        var action = async () => await new ValueTask<Result>(Result.Ok()).CompensateAsync((Func<Result>)null!);
        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
