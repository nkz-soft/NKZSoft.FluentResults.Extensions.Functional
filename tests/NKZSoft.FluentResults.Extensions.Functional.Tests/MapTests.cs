namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTests : MapTestsBase
{
    [Fact]
    public void MapReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).Map(MapFunc);
        AssertFailure(output);
    }

    [Fact]
    public void MapSelectsNewResult()
    {
        var output = Result.Ok().Map(MapFunc);
        AssertSuccess(output);
    }

    [Fact]
    public void MapTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = ResultExtensions.Map(Result.Fail<TValue>(ErrorMessage), MapFunc);
        AssertFailure(output);
    }

    [Fact]
    public void MapTSelectsNewResult()
    {
        var output = ResultExtensions.Map(Result.Ok(TValue.Value), MapFunc);
        AssertSuccess(output);
    }
}
