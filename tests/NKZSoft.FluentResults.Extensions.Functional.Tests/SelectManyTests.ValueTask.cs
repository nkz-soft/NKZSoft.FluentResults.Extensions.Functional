namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsValueTask : SelectManyTestsBase
{
    [Test]
    public async Task SelectManyValueTaskReturnsSourceFailure()
    {
        var output = await ValueTaskFailResultTAsync().SelectManyAsync(BindSuccessValueTask, Project);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task SelectManyValueTaskReturnsBindFailure()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindFailureValueTask, Project);

        AssertBindFailure(output);
    }

    [Test]
    public async Task SelectManyValueTaskReturnsProjectedResult()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindSuccessValueTask, Project);

        AssertSuccess(output);
    }
}
