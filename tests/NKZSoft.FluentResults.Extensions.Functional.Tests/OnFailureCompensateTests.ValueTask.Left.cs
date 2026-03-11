namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnFailureCompensateTestsValueTaskLeft : CompensateTestsBase
{
    [Test]
    public async Task OnFailureCompensateAsyncReturnsOriginalValueTaskResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).OnFailureCompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public async Task OnFailureCompensateAsyncExecutesFallbackWhenValueTaskSourceIsFailed()
    {
        var output = await new ValueTask<Result>(Result.Fail(ErrorMessage)).OnFailureCompensateAsync(() => OkCompensate());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task OnFailureCompensateAsyncWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = await new ValueTask<Result>(result).OnFailureCompensateAsync(errors => OkCompensate(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }
}
