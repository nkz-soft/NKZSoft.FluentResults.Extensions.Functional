﻿namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public class FinallyTestsValueValueTaskLeft : FinallyTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultReturnsT(bool isSuccess)
    {
        var result =  ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.FinallyAsync(TValueResultFunc);

        AssertCalled(output);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.FinallyAsync(TValueResultTFunc);

        AssertCalled(output);
    }
}