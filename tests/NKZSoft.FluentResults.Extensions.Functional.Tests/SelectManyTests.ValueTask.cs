namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsValueTask : SelectManyTestsBase
{
    [Fact]
    public async Task SelectManyValueTaskReturnsSourceFailure()
    {
        var output = await ValueTaskFailResultTAsync().SelectManyAsync(BindSuccessValueTask, Project);

        AssertSourceFailure(output);
    }

    [Fact]
    public async Task SelectManyValueTaskReturnsBindFailure()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindFailureValueTask, Project);

        AssertBindFailure(output);
    }

    [Fact]
    public async Task SelectManyValueTaskReturnsProjectedResult()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindSuccessValueTask, Project);

        AssertSuccess(output);
    }
}
