namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindOptionalTestsTaskLeft : BindOptionalTestsBase
{
    [Test]
    public async Task BindOptionalAsyncTaskLeftReferenceReturnsNullWhenSourceValueIsNull()
    {
        var output = await Task.FromResult(Result.Ok<string?>(null)).BindOptionalAsync(BindReference);

        AssertSkippedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncTaskLeftReferenceMapsValueWhenSourceValueIsNotNull()
    {
        var output = await Task.FromResult(Result.Ok<string?>(SourceReferenceValue)).BindOptionalAsync(BindReference);

        AssertMappedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncTaskLeftStructMapsValueWhenSourceValueIsPresent()
    {
        var output = await Task.FromResult(Result.Ok<int?>(SourceStructValue)).BindOptionalAsync(BindStruct);

        AssertMappedStruct(output);
    }
}
