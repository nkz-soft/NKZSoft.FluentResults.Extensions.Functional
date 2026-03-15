namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindOptionalTestsValueTaskRight : BindOptionalTestsBase
{
    [Test]
    public async Task BindOptionalAsyncValueTaskRightReferenceReturnsSourceFailureAndSkipsFunc()
    {
        var output = await Result.Fail<string?>(ErrorMessage).BindOptionalAsync(ValueTaskBindReferenceAsync);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindOptionalAsyncValueTaskRightReferenceReturnsNullWhenSourceValueIsNull()
    {
        var output = await Result.Ok<string?>(null).BindOptionalAsync(ValueTaskBindReferenceAsync);

        AssertSkippedReference(output);
    }

    [Test]
    public async Task BindOptionalAsyncValueTaskRightStructMapsValueWhenSourceValueIsPresent()
    {
        var output = await Result.Ok<int?>(SourceStructValue).BindOptionalAsync(ValueTaskBindStructAsync);

        AssertMappedStruct(output);
    }
}
