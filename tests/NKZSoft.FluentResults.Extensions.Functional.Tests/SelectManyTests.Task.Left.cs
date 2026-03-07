namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsTaskLeft : SelectManyTestsBase
{
    [Fact]
    public async Task SelectManyTaskLeftReturnsSourceFailure()
    {
        var output = await TaskFailResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSourceFailure(output);
    }

    [Fact]
    public async Task SelectManyTaskLeftReturnsBindFailure()
    {
        var output = await TaskOkResultTAsync().SelectManyAsync(BindFailure, Project);

        AssertBindFailure(output);
    }

    [Fact]
    public async Task SelectManyTaskLeftReturnsProjectedResult()
    {
        var output = await TaskOkResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSuccess(output);
    }
}
