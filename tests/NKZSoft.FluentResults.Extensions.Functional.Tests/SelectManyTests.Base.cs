namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class SelectManyTestsBase : TestBase
{
    protected const string BindErrorMessage = "Bind Error Message";

    protected bool ProjectExecuted { get; set; }

    protected class TValueBind
    {
        public static readonly TValueBind Value = new();
    }

    protected class TValueSelectMany
    {
        public static readonly TValueSelectMany Value = new();
    }

    protected Result<TValueBind> BindSuccess(TValue _)
    {
        FuncExecuted = true;
        return Result.Ok(TValueBind.Value);
    }

    protected Result<TValueBind> BindFailure(TValue _)
    {
        FuncExecuted = true;
        return Result.Fail<TValueBind>(BindErrorMessage);
    }

    protected Task<Result<TValueBind>> BindSuccessTask(TValue _)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok(TValueBind.Value));
    }

    protected Task<Result<TValueBind>> BindFailureTask(TValue _)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Fail<TValueBind>(BindErrorMessage));
    }

    protected ValueTask<Result<TValueBind>> BindSuccessValueTask(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok(TValueBind.Value));
    }

    protected ValueTask<Result<TValueBind>> BindFailureValueTask(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Fail<TValueBind>(BindErrorMessage));
    }

    protected TValueSelectMany Project(TValue _, TValueBind __)
    {
        ProjectExecuted = true;
        return TValueSelectMany.Value;
    }

    protected void AssertSourceFailure(Result<TValueSelectMany> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == ErrorMessage);
        FuncExecuted.Should().BeFalse();
        ProjectExecuted.Should().BeFalse();
    }

    protected void AssertBindFailure(Result<TValueSelectMany> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == BindErrorMessage);
        FuncExecuted.Should().BeTrue();
        ProjectExecuted.Should().BeFalse();
    }

    protected void AssertSuccess(Result<TValueSelectMany> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValueSelectMany.Value);
        FuncExecuted.Should().BeTrue();
        ProjectExecuted.Should().BeTrue();
    }
}
