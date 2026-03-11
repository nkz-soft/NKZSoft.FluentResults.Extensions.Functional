namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CheckTestsTaskLeft : CheckTestsBase
{
    [Test]
    public async Task CheckTaskLeftReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail(ErrorMessage);

        var output = await Task.FromResult(result).CheckAsync(() => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Test]
    public async Task CheckTaskLeftReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok();

        var output = await Task.FromResult(result).CheckAsync(() => OkCheck());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CheckTaskLeftReturnsFailedCheckResultWhenCheckFails()
    {
        var result = Result.Ok();
        Result? checkResult = null;

        Result Check()
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = await Task.FromResult(result).CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().BeSameAs(checkResult);
        AssertFailedWithErrors(output, checkResult!);
    }

    [Test]
    public async Task CheckTaskLeftTReturnsOriginalResultWhenSourceIsFailed()
    {
        var result = Result.Fail<TValue>(ErrorMessage);

        var output = await Task.FromResult(result).CheckAsync(() => OkCheck());

        FuncExecuted.Should().BeFalse();
        AssertSameInstance(result, output);
        output.IsFailed.Should().BeTrue();
    }

    [Test]
    public async Task CheckTaskLeftTReturnsOriginalResultWhenCheckSucceeds()
    {
        var result = Result.Ok(TValue.Value);

        var output = await Task.FromResult(result).CheckAsync(() => OkCheck());

        FuncExecuted.Should().BeTrue();
        AssertSameInstance(result, output);
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task CheckTaskLeftTReturnsFailedResultWithCheckErrorsWhenCheckFails()
    {
        var result = Result.Ok(TValue.Value);
        Result? checkResult = null;

        Result Check(TValue value)
        {
            FuncExecuted = true;
            checkResult = Result.Fail(ErrorMessage);
            return checkResult;
        }

        var output = await Task.FromResult(result).CheckAsync(Check);

        FuncExecuted.Should().BeTrue();
        output.Should().NotBeSameAs(result);
        AssertFailedWithErrors(output, checkResult!);
    }
}
