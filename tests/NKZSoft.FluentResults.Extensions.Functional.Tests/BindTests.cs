namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTests : BindTestsBase
{
    [Test]
    public void InternalBindReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage)
            .IternalBind(OkFunc);
        AssertFailure(output);
    }

    [Test]
    public void InternalBindSelectsNewResult()
    {
        var output = Result.Ok()
            .IternalBind(OkFunc);
        AssertSuccess(output);
    }

    [Test]
    public void InternalBindTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage)
            .IternalBind(OkTFunc);
        AssertFailure(output);
    }

    [Test]
    public void InternalBindTSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value)
            .IternalBind(OkTFunc);
        AssertSuccess(output);
    }

    [Test]
    public void BindResultReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).Bind(OkFunc);

        AssertFailure(output);
    }

    [Test]
    public void BindResultSelectsNewResult()
    {
        var output = Result.Ok().Bind(OkFunc);

        AssertSuccess(output);
    }

    [Test]
    public void BindResultToResultTSelectsNewResult()
    {
        var output = Result.Ok().Bind(OkStringFunc);

        AssertSuccess(output);
        output.Value.Should().Be("ok");
    }

    [Test]
    public void BindResultToResultTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).Bind(OkStringFunc);

        AssertFailure(output);
    }

    [Test]
    public void BindResultTToResultSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value).Bind(OkFromTFunc);

        AssertSuccess(output);
    }

    [Test]
    public void BindResultTToResultReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage).Bind(OkFromTFunc);

        AssertFailure(output);
    }

    [Test]
    public void BindResultTToResultPropagatesFuncFailure()
    {
        var output = Result.Ok(TValue.Value).Bind(FailFromTFunc);

        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }

    [Test]
    public void BindResultTToResultTSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value).Bind(OkStringFromTFunc);

        AssertSuccess(output);
        output.Value.Should().Be("ok");
    }

    [Test]
    public void BindResultTToResultTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage).Bind(OkStringFromTFunc);

        AssertFailure(output);
    }

    [Test]
    public void BindResultTToResultTPropagatesFuncFailure()
    {
        var output = Result.Ok(TValue.Value).Bind(FailStringFromTFunc);

        output.IsFailed.Should().BeTrue();
        FuncExecuted.Should().BeTrue();
        output.Errors.Should().Contain(error => error.Message == ErrorMessage);
    }
}
