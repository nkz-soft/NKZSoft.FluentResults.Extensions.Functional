namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class MapErrorTestsBase : TestBase
{
    protected const string SecondErrorMessage = "Second Error Message";
    protected const string SuccessMessage = "Success Message";
    protected const string MappedErrorPrefix = "Mapped: ";

    protected int MapperExecutionCount { get; private set; }

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

    protected IError MapErrorFunc(IError error)
    {
        MapperExecutionCount++;
        return new Error(MappedErrorPrefix + error.Message);
    }

    protected Task<IError> TaskMapErrorFuncAsync(IError error)
    {
        MapperExecutionCount++;
        return Task.FromResult<IError>(new Error(MappedErrorPrefix + error.Message));
    }

    protected ValueTask<IError> ValueTaskMapErrorFuncAsync(IError error)
    {
        MapperExecutionCount++;
        return ValueTask.FromResult<IError>(new Error(MappedErrorPrefix + error.Message));
    }

    protected void AssertUnchanged(Result source, Result output)
    {
        output.Should().BeSameAs(source);
        MapperExecutionCount.Should().Be(0);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }

    protected void AssertUnchanged(Result<TValue> source, Result<TValue> output)
    {
        output.Should().BeSameAs(source);
        MapperExecutionCount.Should().Be(0);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }

    protected void AssertMapped(Result output)
    {
        output.IsFailed.Should().BeTrue();
        MapperExecutionCount.Should().Be(2);
        output.Errors.Select(error => error.Message)
            .Should()
            .Equal(MappedErrorPrefix + ErrorMessage, MappedErrorPrefix + SecondErrorMessage);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }

    protected void AssertMapped(Result<TValue> output)
    {
        output.IsFailed.Should().BeTrue();
        MapperExecutionCount.Should().Be(2);
        output.Errors.Select(error => error.Message)
            .Should()
            .Equal(MappedErrorPrefix + ErrorMessage, MappedErrorPrefix + SecondErrorMessage);
        output.Successes.Should().ContainSingle(success => success.Message == SuccessMessage);
    }
}
