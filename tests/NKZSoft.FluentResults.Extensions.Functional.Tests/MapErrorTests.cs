namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapErrorTests : MapErrorTestsBase
{
    [Test]
    public void MapErrorReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = SucceededResult();

        var output = result.MapError(MapErrorFunc);

        AssertUnchanged(result, output);
    }

    [Test]
    public void MapErrorMapsAllErrorsAndPreservesSuccesses()
    {
        var output = FailedResult().MapError(MapErrorFunc);

        AssertMapped(output);
    }

    [Test]
    public void MapErrorTReturnsOriginalResultWhenSourceIsSuccessful()
    {
        var result = SucceededResultT();

        var output = result.MapError(MapErrorFunc);

        AssertUnchanged(result, output);
    }

    [Test]
    public void MapErrorTMapsAllErrorsAndPreservesSuccesses()
    {
        var output = FailedResultT().MapError(MapErrorFunc);

        AssertMapped(output);
    }

    [Test]
    public void MapErrorThrowsWhenMapperIsNull()
    {
        var action = () => Result.Ok().MapError((Func<IError, IError>)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void MapErrorTThrowsWhenMapperIsNull()
    {
        var action = () => Result.Ok(TValue.Value).MapError((Func<IError, IError>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
