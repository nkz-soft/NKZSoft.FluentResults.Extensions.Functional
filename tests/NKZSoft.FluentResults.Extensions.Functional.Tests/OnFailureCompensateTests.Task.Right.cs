namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnFailureCompensateTestsTaskRight : CompensateTestsBase
{
    [Fact]
    public async Task OnFailureCompensateAsyncReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await result.OnFailureCompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public async Task OnFailureCompensateAsyncExecutesTaskFallbackWhenSourceIsFailed()
    {
        var output = await Result.Fail(ErrorMessage).OnFailureCompensateAsync(() => TaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task OnFailureCompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await result.OnFailureCompensateAsync(errors => TaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }
}
