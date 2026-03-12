namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class GetValueOrDefaultTestsTaskLeft : GetValueOrDefaultTestsBase
{
    [Test]
    public async Task GetValueOrDefaultTaskLeftReturnsResultValueOnSuccess()
    {
        var fallback = new TValue();
        var output = await TaskOkResultTAsync().GetValueOrDefaultAsync(fallback);
        output.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public async Task GetValueOrDefaultTaskLeftReturnsFallbackValueOnFailure()
    {
        var fallback = new TValue();
        var output = await TaskFailResultTAsync().GetValueOrDefaultAsync(fallback);
        output.Should().BeSameAs(fallback);
    }

    [Test]
    public async Task GetValueOrDefaultTaskLeftFactoryRunsOnlyOnFailure()
    {
        var successOutput = await TaskOkResultTAsync().GetValueOrDefaultAsync(DefaultValueFactory);
        successOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeFalse();

        var failedOutput = await TaskFailResultTAsync().GetValueOrDefaultAsync(DefaultValueFactory);
        failedOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public async Task GetValueOrDefaultTaskLeftWithSelectorAndFactoryRunsFactoryOnlyOnFailure()
    {
        var successOutput = await TaskOkResultTAsync().GetValueOrDefaultAsync(SelectValue, DefaultSelectedFactory);
        successOutput.Should().BeSameAs(TValueSelected.Value);
        DefaultExecuted.Should().BeFalse();

        var failedOutput = await TaskFailResultTAsync().GetValueOrDefaultAsync(SelectValue, DefaultSelectedFactory);
        failedOutput.Should().BeSameAs(TValueSelected.Value);
        DefaultExecuted.Should().BeTrue();
    }
}
