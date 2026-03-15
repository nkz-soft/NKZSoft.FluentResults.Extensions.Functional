namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindZipTestsTask : BindZipTestsBase
{
    [Test]
    public async Task BindZipTaskReturnsSourceFailure()
    {
        var output = await TaskFailResultTAsync().BindZipAsync(BindSuccessTask);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindZipTaskReturnsBindFailure()
    {
        var output = await TaskOkResultTAsync().BindZipAsync(BindFailureTask);

        AssertBindFailure(output);
    }

    [Test]
    public async Task BindZipTaskReturnsZippedTuple()
    {
        var output = await TaskOkResultTAsync().BindZipAsync(BindSuccessTask);

        AssertSuccess(output);
    }
}
