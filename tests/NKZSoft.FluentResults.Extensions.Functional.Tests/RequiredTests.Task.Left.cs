namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class RequiredTestsTaskLeft
{
    [Fact]
    public async Task RequiredTaskLeftReturnsFailureWhenValueIsNull()
    {
        var resultTask = Task.FromResult(Result.Ok<string?>(null));

        var output = await resultTask.RequiredAsync("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Value is required");
    }

    [Fact]
    public async Task RequiredTaskLeftReturnsSuccessWhenValueIsNotNull()
    {
        var resultTask = Task.FromResult(Result.Ok<string?>("ok"));

        var output = await resultTask.RequiredAsync("Value is required");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be("ok");
    }

    [Fact]
    public async Task RequiredTaskLeftPreservesSourceErrorsWhenSourceIsFailed()
    {
        var resultTask = Task.FromResult(Result.Fail<string?>("Source failure"));

        var output = await resultTask.RequiredAsync("Value is required");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "Source failure");
        output.Errors.Should().NotContain(x => x.Message == "Value is required");
    }
}
