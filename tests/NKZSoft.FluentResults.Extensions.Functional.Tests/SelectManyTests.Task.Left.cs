namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsTaskLeft : SelectManyTestsBase
{
    [Test]
    public async Task SelectManyTaskLeftReturnsSourceFailure()
    {
        var output = await TaskFailResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task SelectManyTaskLeftReturnsBindFailure()
    {
        var output = await TaskOkResultTAsync().SelectManyAsync(BindFailure, Project);

        AssertBindFailure(output);
    }

    [Test]
    public async Task SelectManyTaskLeftReturnsProjectedResult()
    {
        var output = await TaskOkResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSuccess(output);
    }
}
