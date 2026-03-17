namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class TapErrorTestsBase : TestBase
{
    protected const string SecondErrorMessage = "Second Error Message";
    protected const string SuccessMessage = "Success Message";

    protected int ActionExecutionCount { get; private set; }
    protected int ErrorActionExecutionCount { get; private set; }
    protected List<string> CapturedErrors { get; } = [];

    protected static Result FailedResult()
        => Result.Fail(new Error(ErrorMessage))
            .WithError(new Error(SecondErrorMessage))
            .WithSuccess(SuccessMessage);

    protected static Result<TValue> FailedResultT()
        => Result.Fail<TValue>(new Error(ErrorMessage))
            .WithError(new Error(SecondErrorMessage))
            .WithSuccess(SuccessMessage);

    protected static Result SucceededResult()
        => Result.Ok().WithSuccess(SuccessMessage);

    protected static Result<TValue> SucceededResultT()
        => Result.Ok(TValue.Value).WithSuccess(SuccessMessage);

    protected void Action()
        => ActionExecutionCount++;

    protected Task TaskActionAsync()
    {
        ActionExecutionCount++;
        return Task.CompletedTask;
    }

    protected ValueTask ValueTaskActionAsync()
    {
        ActionExecutionCount++;
        return ValueTask.CompletedTask;
    }

    protected void ErrorAction(IError error)
    {
        ErrorActionExecutionCount++;
        CapturedErrors.Add(error.Message);
    }

    protected Task TaskErrorActionAsync(IError error)
    {
        ErrorActionExecutionCount++;
        CapturedErrors.Add(error.Message);
        return Task.CompletedTask;
    }

    protected ValueTask ValueTaskErrorActionAsync(IError error)
    {
        ErrorActionExecutionCount++;
        CapturedErrors.Add(error.Message);
        return ValueTask.CompletedTask;
    }

    protected void AssertActionInvocation(Result source, Result output)
    {
        output.Should().BeSameAs(source);
        ActionExecutionCount.Should().Be(source.IsFailed ? 1 : 0);
        ErrorActionExecutionCount.Should().Be(0);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }

    protected void AssertActionInvocation(Result<TValue> source, Result<TValue> output)
    {
        output.Should().BeSameAs(source);
        ActionExecutionCount.Should().Be(source.IsFailed ? 1 : 0);
        ErrorActionExecutionCount.Should().Be(0);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }

    protected void AssertErrorInvocation(Result source, Result output)
    {
        output.Should().BeSameAs(source);
        ActionExecutionCount.Should().Be(0);
        ErrorActionExecutionCount.Should().Be(source.IsFailed ? 2 : 0);
        CapturedErrors.Should().Equal(source.IsFailed ? [ErrorMessage, SecondErrorMessage] : []);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }

    protected void AssertErrorInvocation(Result<TValue> source, Result<TValue> output)
    {
        output.Should().BeSameAs(source);
        ActionExecutionCount.Should().Be(0);
        ErrorActionExecutionCount.Should().Be(source.IsFailed ? 2 : 0);
        CapturedErrors.Should().Equal(source.IsFailed ? [ErrorMessage, SecondErrorMessage] : []);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }
}
