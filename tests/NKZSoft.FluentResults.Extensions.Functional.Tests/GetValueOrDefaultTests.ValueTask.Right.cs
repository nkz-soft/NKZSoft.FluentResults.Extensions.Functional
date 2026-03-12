namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class GetValueOrDefaultTestsValueTaskRight : GetValueOrDefaultTestsBase
{
    [Test]
    public async Task GetValueOrDefaultValueTaskRightFactoryRunsOnlyOnFailure()
    {
        var successOutput = await Result.Ok(TValue.Value).GetValueOrDefaultAsync(DefaultValueFactoryValueTask);
        successOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeFalse();

        var failedOutput = await Result.Fail<TValue>(ErrorMessage).GetValueOrDefaultAsync(DefaultValueFactoryValueTask);
        failedOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultValueTaskRightWithSelectorUsesDefaultOnFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).GetValueOrDefaultAsync(SelectValueValueTask, TValueSelected.Value);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
    }

    [Test]
    public async Task GetValueOrDefaultValueTaskRightWithSelectorAndFactoryRunsFactoryOnlyOnFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).GetValueOrDefaultAsync(SelectValueValueTask, DefaultSelectedFactoryValueTask);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
        DefaultExecuted.Should().BeTrue();
    }
}
