namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class GetValueOrDefaultTests : GetValueOrDefaultTestsBase
{
    [Test]
    public void GetValueOrDefaultReturnsResultValueOnSuccess()
    {
        var fallback = new TValue();
        var output = Result.Ok(TValue.Value).GetValueOrDefault(fallback);
        output.Should().BeSameAs(TValue.Value);
    }

    [Test]
    public void GetValueOrDefaultReturnsFallbackValueOnFailure()
    {
        var fallback = new TValue();
        var output = Result.Fail<TValue>(ErrorMessage).GetValueOrDefault(fallback);
        output.Should().BeSameAs(fallback);
    }

    [Test]
    public void GetValueOrDefaultFactoryRunsOnlyOnFailure()
    {
        var successOutput = Result.Ok(TValue.Value).GetValueOrDefault(DefaultValueFactory);
        successOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeFalse();

        var failedOutput = Result.Fail<TValue>(ErrorMessage).GetValueOrDefault(DefaultValueFactory);
        failedOutput.Should().BeSameAs(TValue.Value);
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public void GetValueOrDefaultWithSelectorRunsSelectorOnlyOnSuccess()
    {
        var successOutput = Result.Ok(TValue.Value).GetValueOrDefault(SelectValue, TValueSelected.Value);
        successOutput.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeTrue();

        SelectorExecuted = false;
        var failedOutput = Result.Fail<TValue>(ErrorMessage).GetValueOrDefault(SelectValue, TValueSelected.Value);
        failedOutput.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
    }

    [Test]
    public void GetValueOrDefaultWithSelectorAndFactoryRunsFactoryOnlyOnFailure()
    {
        var successOutput = Result.Ok(TValue.Value).GetValueOrDefault(SelectValue, DefaultSelectedFactory);
        successOutput.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeTrue();
        DefaultExecuted.Should().BeFalse();

        SelectorExecuted = false;
        var failedOutput = Result.Fail<TValue>(ErrorMessage).GetValueOrDefault(SelectValue, DefaultSelectedFactory);
        failedOutput.Should().BeSameAs(TValueSelected.Value);
        SelectorExecuted.Should().BeFalse();
        DefaultExecuted.Should().BeTrue();
    }

    [Test]
    public void GetValueOrDefaultReturnsNullByDefaultForReferenceTypeOnFailure()
    {
        var output = Result.Fail<string?>(ErrorMessage).GetValueOrDefault();
        output.Should().BeNull();
    }

    [Test]
    public void GetValueOrDefaultThrowsWhenFactoryIsNull()
    {
        var action = () => Result.Ok(TValue.Value).GetValueOrDefault((Func<TValue>)null!);
        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void GetValueOrDefaultThrowsWhenSelectorIsNull()
    {
        var action = () => Result.Ok(TValue.Value).GetValueOrDefault((Func<TValue, TValueSelected>)null!, TValueSelected.Value);
        action.Should().Throw<ArgumentNullException>();
    }
}
