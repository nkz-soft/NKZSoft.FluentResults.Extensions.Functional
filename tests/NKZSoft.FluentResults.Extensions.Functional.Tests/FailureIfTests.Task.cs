namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class FailureIfTestsTask
{
    [Test]
    public async Task FailureIfAsyncTaskPredicateReturnsFailWhenPredicateReturnsTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(() => Task.FromResult(true), "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task FailureIfAsyncTaskPredicateReturnsOkWhenPredicateReturnsFalse()
    {
        var output = await ResultExtensions.FailureIfAsync(() => Task.FromResult(false), "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task FailureIfAsyncTaskPredicateWithValueReturnsFailWhenPredicateReturnsTrue()
    {
        var output = await ResultExtensions.FailureIfAsync(() => Task.FromResult(true), 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task FailureIfAsyncTaskPredicateWithValueReturnsOkWithValueWhenPredicateReturnsFalse()
    {
        var value = new object();
        var output = await ResultExtensions.FailureIfAsync(() => Task.FromResult(false), value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Test]
    public async Task FailureIfAsyncTaskPredicateThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.FailureIfAsync((Func<Task<bool>>)null!, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task FailureIfAsyncTaskPredicateWithValueThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.FailureIfAsync((Func<Task<bool>>)null!, 10, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
