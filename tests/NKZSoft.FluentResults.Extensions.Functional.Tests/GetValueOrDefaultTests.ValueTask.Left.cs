namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class GetValueOrDefaultTestsValueTaskLeft : GetValueOrDefaultTestsBase
{
    [Test]
    public async Task GetValueOrDefaultValueTaskLeftReturnsResultValueOnSuccess()
    {
        var fallback = new TValue();
        var output = await ValueTaskOkResultTAsync().GetValueOrDefaultAsync(fallback);
        output.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task GetValueOrDefaultValueTaskLeftFactoryRunsOnlyOnFailure()
    {
        var successOutput = await ValueTaskOkResultTAsync().GetValueOrDefaultAsync(DefaultValueFactory);
        successOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeFalse();

        var failedOutput = await ValueTaskFailResultTAsync().GetValueOrDefaultAsync(DefaultValueFactory);
        failedOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultValueTaskLeftWithSelectorUsesDefaultOnFailure()
    {
        var output = await ValueTaskFailResultTAsync().GetValueOrDefaultAsync(SelectValue, TValueSelected.Value);
        output.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
    }
}
