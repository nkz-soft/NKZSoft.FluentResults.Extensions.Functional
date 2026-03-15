namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using System.Runtime.CompilerServices;
using Common;

public abstract class BindZipTestsBase : TestBase
{
    protected const string BindErrorMessage = "BindZip Error Message";

    protected class TValueZip
    {
        public static readonly TValueZip Value = new();
    }

    protected Result<TValueZip> BindSuccess(TValue _)
    {
        FuncExecuted = true;
        return Result.Ok(TValueZip.Value);
    }

    protected Result<TValueZip> BindFailure(TValue _)
    {
        FuncExecuted = true;
        return Result.Fail<TValueZip>(BindErrorMessage);
    }

    protected Result<TValueZip> BindTuple2Success(TValue _, TValueZip __)
    {
        FuncExecuted = true;
        return Result.Ok(TValueZip.Value);
    }

    protected Result<TValueZip> BindTuple3Success(TValue _, TValueZip __, TValueZip ___)
    {
        FuncExecuted = true;
        return Result.Ok(TValueZip.Value);
    }

    protected Result<TValueZip> BindTuple4Success(TValue _, TValueZip __, TValueZip ___, TValueZip ____)
    {
        FuncExecuted = true;
        return Result.Ok(TValueZip.Value);
    }

    protected Result<TValueZip> BindTuple5Success(TValue _, TValueZip __, TValueZip ___, TValueZip ____, TValueZip _____)
    {
        FuncExecuted = true;
        return Result.Ok(TValueZip.Value);
    }

    protected Result<TValueZip> BindTuple6Success(TValue _, TValueZip __, TValueZip ___, TValueZip ____, TValueZip _____, TValueZip ______)
    {
        FuncExecuted = true;
        return Result.Ok(TValueZip.Value);
    }

    protected Result<TValueZip> BindTuple7Success(TValue _, TValueZip __, TValueZip ___, TValueZip ____, TValueZip _____, TValueZip ______, TValueZip _______)
    {
        FuncExecuted = true;
        return Result.Ok(TValueZip.Value);
    }

    protected Task<Result<TValueZip>> BindSuccessTask(TValue _)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Ok(TValueZip.Value));
    }

    protected Task<Result<TValueZip>> BindFailureTask(TValue _)
    {
        FuncExecuted = true;
        return Task.FromResult(Result.Fail<TValueZip>(BindErrorMessage));
    }

    protected ValueTask<Result<TValueZip>> BindSuccessValueTask(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Ok(TValueZip.Value));
    }

    protected ValueTask<Result<TValueZip>> BindFailureValueTask(TValue _)
    {
        FuncExecuted = true;
        return ValueTask.FromResult(Result.Fail<TValueZip>(BindErrorMessage));
    }

    protected void AssertSourceFailure(Result<(TValue, TValueZip)> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == ErrorMessage);
        FuncExecuted.Should().BeFalse();
    }

    protected void AssertBindFailure(Result<(TValue, TValueZip)> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(e => e.Message == BindErrorMessage);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertSuccess(Result<(TValue First, TValueZip Second)> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.First.Should().BeSameAs(TValue.Value);
        output.Value.Second.Should().BeSameAs(TValueZip.Value);
        FuncExecuted.Should().BeTrue();
    }

    protected static void AssertTupleLength<TTuple>(Result<TTuple> output, int expectedLength)
        where TTuple : notnull
    {
        ((ITuple)output.Value!).Length.Should().Be(expectedLength);
    }
}
