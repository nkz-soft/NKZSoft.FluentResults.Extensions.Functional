namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CompensateTests : CompensateTestsBase
{
    [Fact]
    public void CompensateReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok();

        var output = result.Compensate(() => OkCompensate());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
    }

    [Fact]
    public void CompensateExecutesFallbackWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = result.Compensate(() => OkCompensate());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void CompensateWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail(ErrorMessage);

        _ = result.Compensate(errors => OkCompensate(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Fact]
    public void CompensateTReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.Compensate(() => OkCompensateT());

        FuncExecuted.Should().BeFalse();
        output.Should().BeSameAs(result);
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public void CompensateTExecutesFallbackWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = result.Compensate(() => OkCompensateT());

        FuncExecuted.Should().BeTrue();
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public void CompensateTWithErrorsPassesSourceErrors()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        _ = result.Compensate(errors => OkCompensateT(errors));

        FuncExecuted.Should().BeTrue();
        ReceivedErrors.Should().BeEquivalentTo(result.Errors);
    }

    [Fact]
    public void CompensateThrowsWhenFallbackIsNull()
    {
        var action = () => Result.Ok().Compensate((Func<Result>)null!);
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CompensateWithErrorsThrowsWhenFallbackIsNull()
    {
        var action = () => Result.Ok().Compensate((Func<IReadOnlyCollection<IError>, Result>)null!);
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CompensateTThrowsWhenFallbackIsNull()
    {
        var action = () => Result.Ok(TValue.Value).Compensate((Func<Result<TValue>>)null!);
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CompensateTWithErrorsThrowsWhenFallbackIsNull()
    {
        var action = () => Result.Ok(TValue.Value).Compensate((Func<IReadOnlyCollection<IError>, Result<TValue>>)null!);
        action.Should().Throw<ArgumentNullException>();
    }
}
