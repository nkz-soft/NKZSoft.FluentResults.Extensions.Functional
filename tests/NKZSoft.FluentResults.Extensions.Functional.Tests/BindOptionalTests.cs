namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindOptionalTests : BindOptionalTestsBase
{
    [Test]
    public void BindOptionalReferenceReturnsSourceFailureAndSkipsFunc()
    {
        var output = Result.Fail<string?>(ErrorMessage).BindOptional(BindReference);

        AssertSourceFailure(output);
    }

    [Test]
    public void BindOptionalReferenceReturnsNullWhenSourceValueIsNull()
    {
        var output = Result.Ok<string?>(null).BindOptional(BindReference);

        AssertSkippedReference(output);
    }

    [Test]
    public void BindOptionalReferenceMapsValueWhenSourceValueIsNotNull()
    {
        var output = Result.Ok<string?>(SourceReferenceValue).BindOptional(BindReference);

        AssertMappedReference(output);
    }

    [Test]
    public void BindOptionalStructReturnsNullWhenSourceValueIsNull()
    {
        var output = Result.Ok<int?>(null).BindOptional(BindStruct);

        AssertSkippedStruct(output);
    }

    [Test]
    public void BindOptionalStructMapsValueWhenSourceValueIsPresent()
    {
        var output = Result.Ok<int?>(SourceStructValue).BindOptional(BindStruct);

        AssertMappedStruct(output);
    }

    [Test]
    public void BindOptionalReferenceThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok<string?>(SourceReferenceValue).BindOptional((Func<string, Result<string?>>)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void BindOptionalStructThrowsWhenFuncIsNull()
    {
        var action = () => Result.Ok<int?>(SourceStructValue).BindOptional((Func<int, Result<int?>>)null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
