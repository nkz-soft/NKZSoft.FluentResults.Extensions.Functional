namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTests : BindTestsBase
{
    [Fact]
    public void BindReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage)
            .IternalBind(OkFunc);
        AssertFailure(output);
    }

    [Fact]
    public void BindSelectsNewResult()
    {
        var output = Result.Ok()
            .IternalBind(OkFunc);
        AssertSuccess(output);
    }

    [Fact]
    public void BindTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage)
            .IternalBind(OkTFunc);
        AssertFailure(output);
    }

    [Fact]
    public void BindTSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value)
            .IternalBind(OkTFunc);
        AssertSuccess(output);
    }
}
