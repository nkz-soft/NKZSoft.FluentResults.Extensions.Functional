namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class MatchTestsTaskRight : MatchTestsBase
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResult(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        await result.MatchAsync(TaskSuccessEmpty, TaskFailure);

        AssertSuccess(isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResultReturnsValue(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);
        await result.MatchAsync(TaskValueSuccess, TaskValueFailure);

        AssertSuccess(isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        await result.MatchAsync(TaskValueSuccess, TaskFailure);

        AssertSuccess(isSuccess);
    }

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);
        await result.MatchAsync(TaskValueSuccessT, TaskValueFailureT);

        AssertSuccess(result, isSuccess);
    }
}
