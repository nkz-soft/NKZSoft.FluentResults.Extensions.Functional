namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckTestsValueTaskRight : CheckTestsBase
{
    [Fact]
    public async Task CheckValueTaskRightReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = await result.CheckAsync(() => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskRightReturnsOriginalResultWhenCheckSucceedsSynchronously()
    {
        var result = Result.Ok();

        var output = await result.CheckAsync(() => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskRightReturnsOriginalResultWhenCheckSucceedsAsynchronously()
    {
        var result = Result.Ok();

        var output = await result.CheckAsync(ValueTaskOkCheckYieldAsync);

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskRightReturnsFailedCheckResultWhenCheckFails()
    {
        var result = Result.Ok();
        Result? checkResult = null;

        ValueTask<Result> Check()
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return ValueTask.FromResult(checkResult);
        }

        var output = await result.CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().BeSameAs(checkResult);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public async Task CheckValueTaskRightTReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.CheckAsync(() => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskRightTReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CheckAsync(() => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task CheckValueTaskRightTReturnsFailedResultWithCheckErrorsWhenCheckFails()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        ValueTask<Result> Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return ValueTask.FromResult(checkResult);
        }

        var output = await result.CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }
}
