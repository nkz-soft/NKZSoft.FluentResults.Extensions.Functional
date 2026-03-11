namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompensateTestsValueTaskRight : CompensateTestsBase
{
    [Fact]
    public async Task CompensateAsyncReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await result.CompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public async Task CompensateAsyncExecutesValueTaskFallbackWhenSourceIsFailed()
    {
        var output = await Result.Fail(ErrorMessage).CompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await result.CompensateAsync(errors => ValueTaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Fact]
    public async Task CompensateAsyncTReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CompensateAsync(() => ValueTaskOkCompensateTAsync());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public async Task CompensateAsyncThrowsWhenFallbackIsNull()
    {
        var action = async () => await Result.Ok().CompensateAsync((Func<ValueTask<Result>>)null!);
        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
