namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class GetValueOrDefaultTestsValueTask : GetValueOrDefaultTestsBase
{
    [Test]
    public async Task GetValueOrDefaultValueTaskUsesAsyncFactoryOnFailure()
    {
        var output = await ValueTaskFailResultTAsync().GetValueOrDefaultAsync(DefaultValueFactoryTask);
        output.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultValueTaskSupportsValueTaskFactoryOnFailure()
    {
        var output = await ValueTaskFailResultTAsync().GetValueOrDefaultAsync(DefaultValueFactoryValueTask);
        output.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultValueTaskWithAsyncSelectorUsesSelectorOnSuccess()
    {
        var output = await ValueTaskOkResultTAsync().GetValueOrDefaultAsync(SelectValueTask, TValueSelected.Value);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultValueTaskWithValueTaskSelectorUsesFactoryOnFailure()
    {
        var output = await ValueTaskFailResultTAsync().GetValueOrDefaultAsync(SelectValueValueTask, DefaultSelectedFactoryValueTask);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
        DefaultExecuted.Should().BeTrue();
    }
}
