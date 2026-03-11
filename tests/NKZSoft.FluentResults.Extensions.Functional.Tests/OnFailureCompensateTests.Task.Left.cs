namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnFailureCompensateTestsTaskLeft : CompensateTestsBase
{
    [Fact]
    public async Task OnFailureCompensateAsyncReturnsOriginalTaskResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await Task.FromResult(result).OnFailureCompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public async Task OnFailureCompensateAsyncExecutesFallbackWhenTaskSourceIsFailed()
    {
        var output = await Task.FromResult(Result.Fail(ErrorMessage)).OnFailureCompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task OnFailureCompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await Task.FromResult(result).OnFailureCompensateAsync(errors => OkCompensate(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }
}
