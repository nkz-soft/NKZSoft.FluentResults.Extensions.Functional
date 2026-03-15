namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindOptionalTestsValueTaskLeft : BindOptionalTestsBase
{
    [Test]
    public async Task BindOptionalAsyncValueTaskLeftReferenceReturnsNullWhenSourceValueIsNull()
    {
        var output = await ValueTask.FromResult(Result.Ok<string?>(null)).BindOptionalAsync(BindReference);

        AssertSkippedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncValueTaskLeftReferenceMapsValueWhenSourceValueIsNotNull()
    {
        var output = await ValueTask.FromResult(Result.Ok<string?>(SourceReferenceValue)).BindOptionalAsync(BindReference);

        AssertMappedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncValueTaskLeftStructMapsValueWhenSourceValueIsPresent()
    {
        var output = await ValueTask.FromResult(Result.Ok<int?>(SourceStructValue)).BindOptionalAsync(BindStruct);

        AssertMappedStruct(output);
    }
}
