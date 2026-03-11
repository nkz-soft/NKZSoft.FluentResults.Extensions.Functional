namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTests : SelectManyTestsBase
{
    [Test]
    public void SelectManyReturnsSourceFailure()
    {
        var output = Result.Fail<TValue>(ErrorMessage).SelectMany(BindSuccess, Project);

        AssertSourceFailure(output);
    }

    [Test]
    public void SelectManyReturnsBindFailure()
    {
        var output = Result.Ok(TValue.Value).SelectMany(BindFailure, Project);

        AssertBindFailure(output);
    }

    [Test]
    public void SelectManyReturnsProjectedResult()
    {
        var output = Result.Ok(TValue.Value).SelectMany(BindSuccess, Project);

        AssertSuccess(output);
    }

    [Test]
    public void SelectManyWithNullBindExpectedThrowArgumentNullException()
    {
        var action = () => Result.Ok(TValue.Value).SelectMany((Func<TValue, Result<TValueBind>>)null!, Project);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void SelectManyWithNullProjectExpectedThrowArgumentNullException()
    {
        var action = () => Result.Ok(TValue.Value).SelectMany(BindSuccess, (Func<TValue, TValueBind, TValueSelectMany>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
