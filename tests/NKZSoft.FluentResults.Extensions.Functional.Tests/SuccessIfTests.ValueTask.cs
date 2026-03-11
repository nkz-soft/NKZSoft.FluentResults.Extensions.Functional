namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SuccessIfTestsValueTask
{
    [Test]
    public async Task SuccessIfAsyncValueTaskPredicateReturnsOkWhenPredicateReturnsTrue()
    {
        var output = await ResultExtensions.SuccessIfAsync(() => ValueTask.FromResult(true), "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task SuccessIfAsyncValueTaskPredicateReturnsFailWhenPredicateReturnsFalse()
    {
        var output = await ResultExtensions.SuccessIfAsync(() => ValueTask.FromResult(false), "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task SuccessIfAsyncValueTaskPredicateWithValueReturnsOkWithValueWhenPredicateReturnsTrue()
    {
        var value = new object();
        var output = await ResultExtensions.SuccessIfAsync(() => ValueTask.FromResult(true), value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Test]
    public async Task SuccessIfAsyncValueTaskPredicateWithValueReturnsFailWhenPredicateReturnsFalse()
    {
        var output = await ResultExtensions.SuccessIfAsync(() => ValueTask.FromResult(false), 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task SuccessIfAsyncValueTaskPredicateThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.SuccessIfAsync((Func<ValueTask<bool>>)null!, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SuccessIfAsyncValueTaskPredicateWithValueThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.SuccessIfAsync((Func<ValueTask<bool>>)null!, 10, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
