namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsValueTaskLeft : SelectManyTestsBase
{
    [Test]
    public async Task SelectManyValueTaskLeftReturnsSourceFailure()
    {
        var output = await ValueTaskFailResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSourceFailure(output);
    }

    [Test]
    public async Task SelectManyValueTaskLeftReturnsBindFailure()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindFailure, Project);

        AssertBindFailure(output);
    }

    [Test]
    public async Task SelectManyValueTaskLeftReturnsProjectedResult()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSuccess(output);
    }
}
