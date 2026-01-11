namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckTestsTaskRight : CheckTestsBase
{
    [Fact]
    public async Task CheckTaskRightReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = await result.CheckAsync(() => TaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckTaskRightReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok();

        var output = await result.CheckAsync(() => TaskOkCheckAsync());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CheckTaskRightReturnsFailedCheckResultWhenCheckFails()
    {
        var result = Result.Ok();
        Result? checkResult = null;

        Task<Result> Check()
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return Task.FromResult(checkResult);
        }

        var output = await result.CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().BeSameAs(checkResult);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Fact]
    public async Task CheckTaskRightTReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await result.CheckAsync(() => TaskOkCheckAsync());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Fact]
    public async Task CheckTaskRightTReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok(TValue.Value);

        var output = await result.CheckAsync(() => TaskOkCheckAsync());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Fact]
    public async Task CheckTaskRightTReturnsFailedResultWithCheckErrorsWhenCheckFails()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Task<Result> Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return Task.FromResult(checkResult);
        }

        var output = await result.CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }
}
