namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class BindTests : BindTestsBase
{
    [Fact]
    public void BindReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).IternalBind(Success);
        AssertFailure(output);
    }

    [Fact]
    public void BindSelectsNewResult()
    {
        var output = Result.Ok().IternalBind(Success);
        AssertSuccess(output);
    }

    [Fact]
    public void BindTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<string>(ErrorMessage)
            .IternalBind(SuccessT);
        AssertFailure(output);
    }

    [Fact]
    public void BindTSelectsNewResult()
    {
        var output = SuccessT(Value).IternalBind(SuccessT);
        AssertSuccess(output);
    }
}
