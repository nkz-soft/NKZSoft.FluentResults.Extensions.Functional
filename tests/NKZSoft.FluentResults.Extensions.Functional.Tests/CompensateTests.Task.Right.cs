namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompensateTestsTaskRight : CompensateTestsBase
{
    [Test]
    public async Task CompensateAsyncReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await result.CompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task CompensateAsyncExecutesTaskFallbackWhenSourceIsFailed()
    {
        var output = await Result.Fail(ErrorMessage).CompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await result.CompensateAsync(errors => TaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Test]
    public async Task CompensateAsyncTReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CompensateAsync(() => TaskOkCompensateTAsync());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task CompensateAsyncThrowsWhenFallbackIsNull()
    {
        var action = async () => await Result.Ok().CompensateAsync((Func<Task<Result>>)null!);
        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
