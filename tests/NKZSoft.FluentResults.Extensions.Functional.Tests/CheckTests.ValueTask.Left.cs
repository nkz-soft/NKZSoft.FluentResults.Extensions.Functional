namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckTestsValueTaskLeft : CheckTestsBase
{
    [Fact]
    public async Task CheckValueTaskLeftReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = await new ValueTask<Result>(result).CheckAsync(OkCheck);

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskLeftReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).CheckAsync(OkCheck);

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskLeftReturnsFailedCheckResultWhenCheckFails()
    {
        var result = Result.Ok();
        Result? checkResult = null;

        Result Check()
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = await new ValueTask<Result>(result).CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().BeSameAs(checkResult);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public async Task CheckValueTaskLeftTReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).CheckAsync(() => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskLeftTReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).CheckAsync(() => OkCheck());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task CheckValueTaskLeftTReturnsFailedResultWithCheckErrorsWhenCheckFails()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Result Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = await new ValueTask<Result<TValue>>(result).CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }
}
