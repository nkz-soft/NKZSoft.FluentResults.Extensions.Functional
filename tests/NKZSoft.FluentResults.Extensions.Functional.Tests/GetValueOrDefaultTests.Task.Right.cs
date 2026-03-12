namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class GetValueOrDefaultTestsTaskRight : GetValueOrDefaultTestsBase
{
    [Test]
    public async Task GetValueOrDefaultTaskRightFactoryRunsOnlyOnFailure()
    {
        var successOutput = await Result.Ok(TValue.Value).GetValueOrDefaultAsync(DefaultValueFactoryTask);
        successOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeFalse();

        var failedOutput = await Result.Fail<TValue>(ErrorMessage).GetValueOrDefaultAsync(DefaultValueFactoryTask);
        failedOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultTaskRightWithSelectorUsesDefaultOnFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).GetValueOrDefaultAsync(SelectValueTask, TValueSelected.Value);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
    }

    [Test]
    public async Task GetValueOrDefaultTaskRightWithSelectorAndFactoryRunsFactoryOnlyOnFailure()
    {
        var successOutput = await Result.Ok(TValue.Value).GetValueOrDefaultAsync(SelectValueTask, DefaultSelectedFactoryTask);
        successOutput.Should().BeSameAs(TValueSelected.Value);
        DefaultExecuted.Should().BeFalse();

        var failedOutput = await Result.Fail<TValue>(ErrorMessage).GetValueOrDefaultAsync(SelectValueTask, DefaultSelectedFactoryTask);
        failedOutput.Should().BeSameAs(TValueSelected.Value);
        DefaultExecuted.Should().BeTrue();
    }
}
