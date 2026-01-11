namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckTestsValueTask : CheckTestsBase
{
    [Fact]
    public async Task CheckValueTaskReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = await new ValueTask<Result>(result).CheckAsync(ValueTaskOkCheckAsync);

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok();

        var output = await new ValueTask<Result>(result).CheckAsync(ValueTaskOkCheckAsync);

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskReturnsFailedCheckResultWhenCheckFails()
    {
        var result = Result.Ok();
        Result? checkResult = null;

        ValueTask<Result> Check()
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return ValueTask.FromResult(checkResult);
        }

        var output = await new ValueTask<Result>(result).CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().BeSameAs(checkResult);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public async Task CheckValueTaskTReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await new ValueTask<Result<TValue>>(result).CheckAsync(() => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckValueTaskTReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok(TValue.Value);

        var output = await new ValueTask<Result<TValue>>(result).CheckAsync(() => ValueTaskOkCheckAsync());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task CheckValueTaskTReturnsFailedResultWithCheckErrorsWhenCheckFails()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        ValueTask<Result> Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return ValueTask.FromResult(checkResult);
        }

        var output = await new ValueTask<Result<TValue>>(result).CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }
}
