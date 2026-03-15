namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindOptionalTestsTaskRight : BindOptionalTestsBase
{
    [Test]
    public async Task BindOptionalAsyncTaskRightReferenceReturnsSourceFailureAndSkipsFunc()
    {
        var output = await Result.Fail<string?>(ErrorMessage).BindOptionalAsync(TaskBindReferenceAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindOptionalAsyncTaskRightReferenceReturnsNullWhenSourceValueIsNull()
    {
        var output = await Result.Ok<string?>(null).BindOptionalAsync(TaskBindReferenceAsync);

        AssertSkippedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncTaskRightStructMapsValueWhenSourceValueIsPresent()
    {
        var output = await Result.Ok<int?>(SourceStructValue).BindOptionalAsync(TaskBindStructAsync);

        AssertMappedStruct(output);
    }
}
