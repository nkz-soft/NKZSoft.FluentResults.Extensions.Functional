namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTests : MapTestsBase
{
    [Test]
    public void MapReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).Map(MapFunc);
        AssertFailure(output);
    }

    [Test]
    public void MapSelectsNewResult()
    {
        var output = Result.Ok().Map(MapFunc);
        AssertSuccess(output);
    }

    [Test]
    public void MapTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = ResultExtensions.Map(Result.Fail<TValue>(ErrorMessage), MapFunc);
        AssertFailure(output);
    }

    [Test]
    public void MapTSelectsNewResult()
    {
        var output = ResultExtensions.Map(Result.Ok(TValue.Value), MapFunc);
        AssertSuccess(output);
    }
}
