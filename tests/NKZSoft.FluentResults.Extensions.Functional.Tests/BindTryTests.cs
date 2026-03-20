namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindTryTests : BindTryTestsBase
{
    [Test]
    public void BindTryReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail(ErrorMessage).BindTry(OkResultFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public void BindTrySelectsNewResult()
    {
        var output = Result.Ok().BindTry(OkResultFunc);

        AssertSuccess(output);
    }

    [Test]
    public void BindTryConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok().BindTry(ThrowResultFunc);

        AssertDefaultFailure(output);
    }

    [Test]
    public void BindTryResultToResultTSelectsNewResult()
    {
        var output = Result.Ok().BindTry(OkResultTFunc);

        AssertSuccess(output);
    }

    [Test]
    public void BindTryResultToResultTConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok().BindTry(ThrowResultTFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public void BindTryResultToResultTConvertsExceptionToFailureWithCustomIError()
    {
        var output = Result.Ok().BindTry(ThrowResultTFunc, CustomIErrorHandler);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error =>
            error.Message == CustomErrorMessage &&
            error.Metadata.ContainsKey(MetadataKey) &&
            Equals(error.Metadata[MetadataKey], MetadataValue));
    }

    [Test]
    public void BindTryTResultToResultReturnsSourceFailureAndDoesNotExecuteFunc()
    {
        var output = Result.Fail<TValue>(ErrorMessage).BindTry(OkResultFromTFunc);

        AssertSourceFailure(output);
    }

    [Test]
    public void BindTryTResultToResultSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value).BindTry(OkResultFromTFunc);

        AssertSuccess(output);
    }

    [Test]
    public void BindTryTResultToResultConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok(TValue.Value).BindTry(ThrowResultFromTFunc, CustomErrorHandler);

        AssertCustomFailure(output);
    }

    [Test]
    public void BindTryTResultToResultTSelectsNewResult()
    {
        var output = Result.Ok(TValue.Value).BindTry(OkResultTFromTFunc);

        AssertSuccess(output);
    }

    [Test]
    public void BindTryTResultToResultTConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok(TValue.Value).BindTry(ThrowResultTFromTFunc);

        AssertDefaultFailure(output);
    }

    [Test]
    public void BindTryThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok().BindTry((Func<Result>)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void BindTryResultToResultTThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok().BindTry((Func<Result<TValueMapped>>)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void BindTryTResultToResultThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok(TValue.Value).BindTry((Func<TValue, Result>)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void BindTryTResultToResultTThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok(TValue.Value).BindTry((Func<TValue, Result<TValueMapped>>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
