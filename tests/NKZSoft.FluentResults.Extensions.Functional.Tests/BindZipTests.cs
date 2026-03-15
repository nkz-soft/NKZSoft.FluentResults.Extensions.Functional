namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindZipTests : BindZipTestsBase
{
    [Test]
    public void BindZipReturnsSourceFailure()
    {
        var output = Result.Fail<TValue>(ErrorMessage).BindZip(BindSuccess);

        AssertSourceFailure(output);
    }

    [Test]
    public void BindZipReturnsBindFailure()
    {
        var output = Result.Ok(TValue.Value).BindZip(BindFailure);

        AssertBindFailure(output);
    }

    [Test]
    public void BindZipReturnsZippedTuple()
    {
        var output = Result.Ok(TValue.Value).BindZip(BindSuccess);

        AssertSuccess(output);
    }

    [Test]
    public void BindZipCanChainToEightTupleValues()
    {
        var output = Result.Ok(TValue.Value)
            .BindZip(BindSuccess)
            .BindZip(BindTuple2Success)
            .BindZip(BindTuple3Success)
            .BindZip(BindTuple4Success)
            .BindZip(BindTuple5Success)
            .BindZip(BindTuple6Success)
            .BindZip(BindTuple7Success);

        output.IsSuccess.Should().BeTrue();
        AssertTupleLength(output, 8);
    }

    [Test]
    public void BindZipWithNullFuncExpectedThrowArgumentNullException()
    {
        var action = () => Result.Ok(TValue.Value).BindZip((Func<TValue, Result<TValueZip>>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
