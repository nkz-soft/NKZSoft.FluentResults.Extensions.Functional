namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsValueTaskRight : SelectManyTestsBase
{
    [Test]
    public async Task SelectManyValueTaskRightReturnsSourceFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).SelectManyAsync(BindSuccessValueTask, Project);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task SelectManyValueTaskRightReturnsBindFailure()
    {
        var output = await Result.Ok(TValue.Value).SelectManyAsync(BindFailureValueTask, Project);

        AssertBindFailure(output);
    }

    [Test]
    public async Task SelectManyValueTaskRightReturnsProjectedResult()
    {
        var output = await Result.Ok(TValue.Value).SelectManyAsync(BindSuccessValueTask, Project);

        AssertSuccess(output);
    }
}
