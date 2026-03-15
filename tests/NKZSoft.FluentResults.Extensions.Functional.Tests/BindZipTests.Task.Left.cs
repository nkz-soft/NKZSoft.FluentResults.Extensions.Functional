namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindZipTestsTaskLeft : BindZipTestsBase
{
    [Test]
    public async Task BindZipTaskLeftReturnsSourceFailure()
    {
        var output = await TaskFailResultTAsync().BindZipAsync(BindSuccess);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindZipTaskLeftReturnsBindFailure()
    {
        var output = await TaskOkResultTAsync().BindZipAsync(BindFailure);

        AssertBindFailure(output);
    }

    [Test]
    public async Task BindZipTaskLeftReturnsZippedTuple()
    {
        var output = await TaskOkResultTAsync().BindZipAsync(BindSuccess);

        AssertSuccess(output);
    }
}
