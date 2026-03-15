namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindZipTestsTaskRight : BindZipTestsBase
{
    [Test]
    public async Task BindZipTaskRightReturnsSourceFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).BindZipAsync(BindSuccessTask);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindZipTaskRightReturnsBindFailure()
    {
        var output = await Result.Ok(TValue.Value).BindZipAsync(BindFailureTask);

        AssertBindFailure(output);
    }

    [Test]
    public async Task BindZipTaskRightReturnsZippedTuple()
    {
        var output = await Result.Ok(TValue.Value).BindZipAsync(BindSuccessTask);

        AssertSuccess(output);
    }
}
