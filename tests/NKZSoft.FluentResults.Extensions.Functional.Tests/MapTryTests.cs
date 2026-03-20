namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MapTryTests : MapTryTestsBase
{
    [Test]
    public void MapTryReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).MapTry(MapFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public void MapTrySelectsNewResult()
    {
        var output = Result.Ok().MapTry(MapFunc);

        AssertSuccess(output);
    }

    [Test]
    public void MapTryConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok().MapTry(ThrowMapFunc);

        AssertDefaultFailure(output);
    }

    [Test]
    public void MapTryConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok().MapTry(ThrowMapFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public void MapTryConvertsExceptionToFailureWithCustomIError()
    {
        var output = Result.Ok().MapTry(ThrowMapFunc, CustomIErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error =>
            error.Message == CustomErrorMessage &&
            error.Metadata.ContainsKey(MetadataKey) &&
            Equals(error.Metadata[MetadataKey], MetadataValue));
    }

    [Test]
    public void MapTryTReturnsFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage).MapTry(MapFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public void MapTryTSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value).MapTry(MapFunc);

        AssertSuccess(output);
    }

    [Test]
    public void MapTryTConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok(TValue.Value).MapTry(ThrowMapFunc);

        AssertDefaultFailure(output);
    }

    [Test]
    public void MapTryTConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok(TValue.Value).MapTry(ThrowMapFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public void MapTryThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok().MapTry((Func<TValueMapped>)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void MapTryTThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok(TValue.Value).MapTry((Func<TValue, TValueMapped>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
