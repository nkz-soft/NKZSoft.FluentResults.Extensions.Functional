namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FailureIfTestsValueTask
{
    [Fact]
    public async Task FailureIfAsyncValueTaskPredicateReturnsFailWhenPredicateReturnsTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(() => ValueTask.FromResult(true), "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public async Task FailureIfAsyncValueTaskPredicateReturnsOkWhenPredicateReturnsFalse()
    {
        var output = await ResultExtensions.FailureIfAsync(() => ValueTask.FromResult(false), "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task FailureIfAsyncValueTaskPredicateWithValueReturnsFailWhenPredicateReturnsTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(() => ValueTask.FromResult(true), 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Fact]
    public async Task FailureIfAsyncValueTaskPredicateWithValueReturnsOkWithValueWhenPredicateReturnsFalse()
    {
        var value = new object();
        var output = await ResultExtensions.FailureIfAsync(() => ValueTask.FromResult(false), value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Fact]
    public async Task FailureIfAsyncValueTaskPredicateThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.FailureIfAsync((Func<ValueTask<bool>>)null!, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task FailureIfAsyncValueTaskPredicateWithValueThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.FailureIfAsync((Func<ValueTask<bool>>)null!, 10, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
