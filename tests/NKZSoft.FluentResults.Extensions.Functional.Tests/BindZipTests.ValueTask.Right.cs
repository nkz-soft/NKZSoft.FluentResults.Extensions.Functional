namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class BindZipTestsValueTaskRight : BindZipTestsBase
{
    [Test]
    public async Task BindZipValueTaskRightReturnsSourceFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).BindZipAsync(BindSuccessValueTask);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task BindZipValueTaskRightReturnsBindFailure()
    {
        var output = await Result.Ok(TValue.Value).BindZipAsync(BindFailureValueTask);

        AssertBindFailure(output);
    }

    [Test]
    public async Task BindZipValueTaskRightReturnsZippedTuple()
    {
        var output = await Result.Ok(TValue.Value).BindZipAsync(BindSuccessValueTask);

        AssertSuccess(output);
    }
}
