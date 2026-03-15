namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindOptionalTestsTask : BindOptionalTestsBase
{
    [Test]
    public async Task BindOptionalAsyncTaskReferenceReturnsSourceFailureAndSkipsFunc()
    {
        var output = await Task.FromResult(Result.Fail<string?>(ErrorMessage)).BindOptionalAsync(TaskBindReferenceAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindOptionalAsyncTaskReferenceMapsValueWhenSourceValueIsNotNull()
    {
        var output = await Task.FromResult(Result.Ok<string?>(SourceReferenceValue)).BindOptionalAsync(TaskBindReferenceAsync);

        AssertMappedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncTaskStructReturnsNullWhenSourceValueIsNull()
    {
        var output = await Task.FromResult(Result.Ok<int?>(null)).BindOptionalAsync(TaskBindStructAsync);

        AssertSkippedStruct(output);
    }
}
