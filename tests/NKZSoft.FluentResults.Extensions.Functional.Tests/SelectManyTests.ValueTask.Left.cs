namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SelectManyTestsValueTaskLeft : SelectManyTestsBase
{
    [Fact]
    public async Task SelectManyValueTaskLeftReturnsSourceFailure()
    {
        var output = await ValueTaskFailResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSourceFailure(output);
    }

    [Fact]
    public async Task SelectManyValueTaskLeftReturnsBindFailure()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindFailure, Project);

        AssertBindFailure(output);
    }

    [Fact]
    public async Task SelectManyValueTaskLeftReturnsProjectedResult()
    {
        var output = await ValueTaskOkResultTAsync().SelectManyAsync(BindSuccess, Project);

        AssertSuccess(output);
    }
}
