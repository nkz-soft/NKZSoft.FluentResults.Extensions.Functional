namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class GetValueOrDefaultTestsTask : GetValueOrDefaultTestsBase
{
    [Test]
    public async Task GetValueOrDefaultTaskUsesAsyncFactoryOnFailure()
    {
        var output = await TaskFailResultTAsync().GetValueOrDefaultAsync(DefaultValueFactoryTask);
        output.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultTaskSupportsValueTaskFactoryOnFailure()
    {
        var output = await TaskFailResultTAsync().GetValueOrDefaultAsync(DefaultValueFactoryValueTask);
        output.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultTaskWithAsyncSelectorUsesSelectorOnSuccess()
    {
        var output = await TaskOkResultTAsync().GetValueOrDefaultAsync(SelectValueTask, TValueSelected.Value);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultTaskWithValueTaskSelectorUsesFactoryOnFailure()
    {
        var output = await TaskFailResultTAsync().GetValueOrDefaultAsync(SelectValueValueTask, DefaultSelectedFactoryValueTask);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
        DefaultExecuted.Should().BeTrue();
    }
}
