namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsTaskRight : SelectManyTestsBase
{
    [Test]
    public async Task SelectManyTaskRightReturnsSourceFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).SelectManyAsync(BindSuccessTask, Project);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task SelectManyTaskRightReturnsBindFailure()
    {
        var output = await Result.Ok(TValue.Value).SelectManyAsync(BindFailureTask, Project);

        AssertBindFailure(output);
    }

    [Test]
    public async Task SelectManyTaskRightReturnsProjectedResult()
    {
        var output = await Result.Ok(TValue.Value).SelectManyAsync(BindSuccessTask, Project);

        AssertSuccess(output);
    }
}
