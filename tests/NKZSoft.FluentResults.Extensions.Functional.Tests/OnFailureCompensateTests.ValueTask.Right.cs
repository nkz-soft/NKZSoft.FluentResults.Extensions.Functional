namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnFailureCompensateTestsValueTaskRight : CompensateTestsBase
{
    [Fact]
    public async Task OnFailureCompensateAsyncReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await result.OnFailureCompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public async Task OnFailureCompensateAsyncExecutesValueTaskFallbackWhenSourceIsFailed()
    {
        var output = await Result.Fail(ErrorMessage).OnFailureCompensateAsync(() => ValueTaskOkCompensateAsync());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task OnFailureCompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await result.OnFailureCompensateAsync(errors => ValueTaskOkCompensateAsync(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }
}
