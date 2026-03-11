namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnFailureCompensateTests : CompensateTestsBase
{
    [Test]
    public void OnFailureCompensateReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = result.OnFailureCompensate(() => OkCompensate());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public void OnFailureCompensateExecutesFallbackWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = result.OnFailureCompensate(() => OkCompensate());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void OnFailureCompensateWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = result.OnFailureCompensate(errors => OkCompensate(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Test]
    public void OnFailureCompensateTReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.OnFailureCompensate(() => OkCompensateT());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Test]
    public void OnFailureCompensateTExecutesFallbackWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = result.OnFailureCompensate(() => OkCompensateT());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public void OnFailureCompensateThrowsWhenFallbackIsNull()
    {
        var action = () => Result.Ok().OnFailureCompensate((Func<Result>)null!);
        action.Should().Throw<ArgumentNullException>();
    }
}
