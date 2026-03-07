namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTests : SelectManyTestsBase
{
    [Fact]
    public void SelectManyReturnsSourceFailure()
    {
        var output = Result.Fail<TValue>(ErrorMessage).SelectMany(BindSuccess, Project);

        AssertSourceFailure(output);
    }

    [Fact]
    public void SelectManyReturnsBindFailure()
    {
        var output = Result.Ok(TValue.Value).SelectMany(BindFailure, Project);

        AssertBindFailure(output);
    }

    [Fact]
    public void SelectManyReturnsProjectedResult()
    {
        var output = Result.Ok(TValue.Value).SelectMany(BindSuccess, Project);

        AssertSuccess(output);
    }

    [Fact]
    public void SelectManyWithNullBindExpectedThrowArgumentNullException()
    {
        var action = () => Result.Ok(TValue.Value).SelectMany((Func<TValue, Result<TValueBind>>)null!, Project);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void SelectManyWithNullProjectExpectedThrowArgumentNullException()
    {
        var action = () => Result.Ok(TValue.Value).SelectMany(BindSuccess, (Func<TValue, TValueBind, TValueSelectMany>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
