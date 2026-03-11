namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class RequiredTestsValueTaskLeft
{
    [Test]
    public async Task RequiredValueTaskLeftReturnsFailureWhenValueIsNull()
    {
        var resultTask = ValueTask.FromResult(Result.Ok<string?>(null));

        var output = await resultTask.RequiredAsync("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value is required");
    }

    [Test]
    public async Task RequiredValueTaskLeftReturnsSuccessWhenValueIsNotNull()
    {
        var resultTask = ValueTask.FromResult(Result.Ok<string?>("ok"));

        var output = await resultTask.RequiredAsync("Value is required");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be("ok");
    }

    [Test]
    public async Task RequiredValueTaskLeftPreservesSourceErrorsWhenSourceIsFailed()
    {
        var resultTask = ValueTask.FromResult(Result.Fail<string?>("Source failure"));

        var output = await resultTask.RequiredAsync("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Source failure");
        output.Errors.Should().NotContain(x => x.Message == "Value is required");
    }
}
