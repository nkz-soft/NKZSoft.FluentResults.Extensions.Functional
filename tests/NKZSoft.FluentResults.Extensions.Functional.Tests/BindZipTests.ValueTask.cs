namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindZipTestsValueTask : BindZipTestsBase
{
    [Test]
    public async Task BindZipValueTaskReturnsSourceFailure()
    {
        var output = await ValueTaskFailResultTAsync().BindZipAsync(BindSuccessValueTask);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindZipValueTaskReturnsBindFailure()
    {
        var output = await ValueTaskOkResultTAsync().BindZipAsync(BindFailureValueTask);

        AssertBindFailure(output);
    }

    [Test]
    public async Task BindZipValueTaskReturnsZippedTuple()
    {
        var output = await ValueTaskOkResultTAsync().BindZipAsync(BindSuccessValueTask);

        AssertSuccess(output);
    }
}
