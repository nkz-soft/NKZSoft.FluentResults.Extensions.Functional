namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class SuccessIfTestsTask
{
    [Test]
    public async Task SuccessIfAsyncTaskPredicateReturnsOkWhenPredicateReturnsTrue()
    {
        var output = await ResultExtensions.SuccessIfAsync(() => Task.FromResult(true), "error");

        output.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task SuccessIfAsyncTaskPredicateReturnsFailWhenPredicateReturnsFalse()
    {
        var output = await ResultExtensions.SuccessIfAsync(() => Task.FromResult(false), "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task SuccessIfAsyncTaskPredicateWithValueReturnsOkWithValueWhenPredicateReturnsTrue()
    {
        var value = new object();
        var output = await ResultExtensions.SuccessIfAsync(() => Task.FromResult(true), value, "error");

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeSameAs(value);
    }

    [Test]
    public async Task SuccessIfAsyncTaskPredicateWithValueReturnsFailWhenPredicateReturnsFalse()
    {
        var output = await ResultExtensions.SuccessIfAsync(() => Task.FromResult(false), 10, "error");

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().Contain(x => x.Message == "error");
    }

    [Test]
    public async Task SuccessIfAsyncTaskPredicateThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.SuccessIfAsync((Func<Task<bool>>)null!, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task SuccessIfAsyncTaskPredicateWithValueThrowsWhenPredicateIsNull()
    {
        var action = async () => await ResultExtensions.SuccessIfAsync((Func<Task<bool>>)null!, 10, "error");

        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}
