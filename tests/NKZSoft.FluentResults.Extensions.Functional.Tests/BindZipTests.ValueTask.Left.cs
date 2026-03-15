namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindZipTestsValueTaskLeft : BindZipTestsBase
{
    [Test]
    public async Task BindZipValueTaskLeftReturnsSourceFailure()
    {
        var output = await ValueTaskFailResultTAsync().BindZipAsync(BindSuccess);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindZipValueTaskLeftReturnsBindFailure()
    {
        var output = await ValueTaskOkResultTAsync().BindZipAsync(BindFailure);

        AssertBindFailure(output);
    }

    [Test]
    public async Task BindZipValueTaskLeftReturnsZippedTuple()
    {
        var output = await ValueTaskOkResultTAsync().BindZipAsync(BindSuccess);

        AssertSuccess(output);
    }
}
