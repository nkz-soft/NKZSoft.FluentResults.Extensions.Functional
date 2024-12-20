﻿namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class MatchTestsTask : MatchTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResult(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(TaskSuccessEmpty, TaskFailure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultReturnsValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage).AsTask();
        await result.MatchAsync(TaskValueSuccess, TaskValueFailure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(TaskValueSuccess, TaskFailure);

        AssertSuccess(isSuccess);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task MatchResultTValue(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value).AsTask();
        await result.MatchAsync(TaskValueSuccessT, TaskValueFailureT);

        AssertSuccess(isSuccess);
    }
}
