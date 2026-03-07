namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsTask : SelectManyTestsBase
{
    [Fact]
    public async Task SelectManyTaskReturnsSourceFailure()
    {
        var output = await TaskFailResultTAsync().SelectManyAsync(BindSuccessTask, Project);

        AssertSourceFailure(output);
    }

    [Fact]
    public async Task SelectManyTaskReturnsBindFailure()
    {
        var output = await TaskOkResultTAsync().SelectManyAsync(BindFailureTask, Project);

        AssertBindFailure(output);
    }

    [Fact]
    public async Task SelectManyTaskReturnsProjectedResult()
    {
        var output = await TaskOkResultTAsync().SelectManyAsync(BindSuccessTask, Project);

        AssertSuccess(output);
    }
}
