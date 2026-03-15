namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindOptionalTestsValueTask : BindOptionalTestsBase
{
    [Test]
    public async Task BindOptionalAsyncValueTaskReferenceReturnsSourceFailureAndSkipsFunc()
    {
        var output = await ValueTask.FromResult(Result.Fail<string?>(ErrorMessage)).BindOptionalAsync(ValueTaskBindReferenceAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindOptionalAsyncValueTaskReferenceMapsValueWhenSourceValueIsNotNull()
    {
        var output = await ValueTask.FromResult(Result.Ok<string?>(SourceReferenceValue)).BindOptionalAsync(ValueTaskBindReferenceAsync);

        AssertMappedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncValueTaskStructReturnsNullWhenSourceValueIsNull()
    {
        var output = await ValueTask.FromResult(Result.Ok<int?>(null)).BindOptionalAsync(ValueTaskBindStructAsync);

        AssertSkippedStruct(output);
    }
}
