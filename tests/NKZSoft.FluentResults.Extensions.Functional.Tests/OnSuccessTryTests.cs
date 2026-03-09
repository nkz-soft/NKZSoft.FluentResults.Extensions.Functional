namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class OnSuccessTryTests : OnSuccessTryTestsBase
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void OnSuccessTryExecutesActionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = Result.OkIf(isSuccess, ErrorMessage);

        var output = result.OnSuccessTry(ActionEmpty);

        AssertState(output, isSuccess, isSuccess);
        if (!isSuccess)
        {
            output.Errors.Should().ContainSingle(error => error.Message == ErrorMessage);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void OnSuccessTryTExecutesActionOnlyWhenResultIsSuccessful(bool isSuccess)
    {
        var result = ResultExtensions.OkIf(isSuccess, ErrorMessage, TValue.Value);

        var output = result.OnSuccessTry(ActionWithValue);

        AssertState(output, isSuccess, isSuccess);
        if (!isSuccess)
        {
            output.Errors.Should().ContainSingle(error => error.Message == ErrorMessage);
        }
    }

    [Fact]
    public void OnSuccessTryConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok().OnSuccessTry(ThrowAction);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Fact]
    public void OnSuccessTryConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok().OnSuccessTry(ThrowAction, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Fact]
    public void OnSuccessTryTConvertsExceptionToFailureWithDefaultError()
    {
        var output = Result.Ok(TValue.Value).OnSuccessTry(ThrowActionWithValue);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == TryExceptionMessage);
    }

    [Fact]
    public void OnSuccessTryTConvertsExceptionToFailureWithCustomError()
    {
        var output = Result.Ok(TValue.Value).OnSuccessTry(ThrowActionWithValue, CustomErrorHandler);

        AssertState(output, true, false);
        output.Errors.Should().ContainSingle(error => error.Message == CustomErrorMessage);
    }

    [Fact]
    public void OnSuccessTryThrowsWhenActionIsNull()
    {
        var action = () => Result.Ok().OnSuccessTry(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void OnSuccessTryTThrowsWhenActionIsNull()
    {
        var action = () => Result.Ok(TValue.Value).OnSuccessTry(null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
