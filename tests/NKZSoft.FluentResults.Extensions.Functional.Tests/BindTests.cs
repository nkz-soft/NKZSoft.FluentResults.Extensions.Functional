namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTests : BindTestsBase
{
    [Fact]
    public void InternalBindReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage)
            .IternalBind(OkFunc);
        AssertFailure(output);
    }

    [Fact]
    public void InternalBindSelectsNewResult()
    {
        var output = Result.Ok()
            .IternalBind(OkFunc);
        AssertSuccess(output);
    }

    [Fact]
    public void InternalBindTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage)
            .IternalBind(OkTFunc);
        AssertFailure(output);
    }

    [Fact]
    public void InternalBindTSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value)
            .IternalBind(OkTFunc);
        AssertSuccess(output);
    }

    [Fact]
    public void BindResultReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).Bind(OkFunc);

        AssertFailure(output);
    }

    [Fact]
    public void BindResultSelectsNewResult()
    {
        var output = Result.Ok().Bind(OkFunc);

        AssertSuccess(output);
    }

    [Fact]
    public void BindResultToResultTSelectsNewResult()
    {
        var output = Result.Ok().Bind(OkStringFunc);

        AssertSuccess(output);
        output.Value.Should().Be("ok");
    }

    [Fact]
    public void BindResultToResultTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).Bind(OkStringFunc);

        AssertFailure(output);
    }

    [Fact]
    public void BindResultTToResultSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value).Bind(OkFromTFunc);

        AssertSuccess(output);
    }

    [Fact]
    public void BindResultTToResultReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage).Bind(OkFromTFunc);

        AssertFailure(output);
    }

    [Fact]
    public void BindResultTToResultPropagatesFuncFailure()
    {
        var output = Result.Ok(TValue.Value).Bind(FailFromTFunc);

        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }

    [Fact]
    public void BindResultTToResultTSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value).Bind(OkStringFromTFunc);

        AssertSuccess(output);
        output.Value.Should().Be("ok");
    }

    [Fact]
    public void BindResultTToResultTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage).Bind(OkStringFromTFunc);

        AssertFailure(output);
    }

    [Fact]
    public void BindResultTToResultTPropagatesFuncFailure()
    {
        var output = Result.Ok(TValue.Value).Bind(FailStringFromTFunc);

        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
