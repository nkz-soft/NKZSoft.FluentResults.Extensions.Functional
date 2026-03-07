namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsValueTaskRight : SelectManyTestsBase
{
    [Fact]
    public async Task SelectManyValueTaskRightReturnsSourceFailure()
    {
        var output = await Result.Fail<TValue>(ErrorMessage).SelectManyAsync(BindSuccessValueTask, Project);

        AssertSourceFailure(output);
    }

    [Fact]
    public async Task SelectManyValueTaskRightReturnsBindFailure()
    {
        var output = await Result.Ok(TValue.Value).SelectManyAsync(BindFailureValueTask, Project);

        AssertBindFailure(output);
    }

    [Fact]
    public async Task SelectManyValueTaskRightReturnsProjectedResult()
    {
        var output = await Result.Ok(TValue.Value).SelectManyAsync(BindSuccessValueTask, Project);

        AssertSuccess(output);
    }
}
