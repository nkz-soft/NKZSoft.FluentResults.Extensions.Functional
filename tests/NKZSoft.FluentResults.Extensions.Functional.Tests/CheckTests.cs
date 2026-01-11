namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckTests : CheckTestsBase
{
    [Fact]
    public void CheckReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = result.Check(() => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void CheckReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok();

        var output = result.Check(() => OkCheck());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void CheckReturnsFailedCheckResultWhenCheckFails()
    {
        var result = Result.Ok();
        Result? checkResult = null;

        Result Check()
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = result.Check(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().BeSameAs(checkResult);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public void CheckTReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = result.Check(() => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void CheckTReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok(TValue.Value);

        var output = result.Check(() => OkCheck());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public void CheckTReturnsFailedResultWithCheckErrorsWhenCheckFails()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Result Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = result.Check(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }
}
