﻿namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FinallyTestsValueTask : FinallyTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage);
        var output = await result.FinallyAsync(ValueTaskTValueResultFuncAsync);

        AssertCalled(output);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FinallyResultTReturnsT(bool isSuccess)
    {
        var result = ResultExtensions.OkIfAsync(isSuccess, ErrorMessage, TValue.Value);
        var output = await result.FinallyAsync(ValueTaskTValueResultTFuncAsync);

        AssertCalled(output);
    }
}
