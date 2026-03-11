namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectTests : SelectTestsBase
{
    [Test]
    public void SelectReturnsFailureAndDoesNotExecuteSelector()
    {
        var output = Result.Fail(ErrorMessage).Select(SelectFunc);
        AssertFailure(output);
    }

    [Test]
    public void SelectProjectsNewResult()
    {
        var output = Result.Ok().Select(SelectFunc);
        AssertSuccess(output);
    }

    [Test]
    public void SelectTReturnsFailureAndDoesNotExecuteSelector()
    {
        var output = ResultExtensions.Select(Result.Fail<TValue>(ErrorMessage), SelectFunc);
        AssertFailure(output);
    }

    [Test]
    public void SelectTProjectsNewResult()
    {
        var output = ResultExtensions.Select(Result.Ok(TValue.Value), SelectFunc);
        AssertSuccess(output);
    }
}
