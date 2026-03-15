namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

using Common;

public abstract class BindOptionalTestsBase : TestBase
{
    protected const string SourceReferenceValue = "source";
    protected const string MappedReferenceValue = "mapped";
    protected const int SourceStructValue = 42;
    protected const int MappedStructValue = 84;

    protected Result<string?> BindReference(string value)
    {
        FuncExecuted = true;
        value.Should().Be(SourceReferenceValue);
        return Result.Ok<string?>(MappedReferenceValue);
    }

    protected Result<int?> BindStruct(int value)
    {
        FuncExecuted = true;
        value.Should().Be(SourceStructValue);
        return Result.Ok<int?>(MappedStructValue);
    }

    protected Task<Result<string?>> TaskBindReferenceAsync(string value)
    {
        FuncExecuted = true;
        value.Should().Be(SourceReferenceValue);
        return Task.FromResult(Result.Ok<string?>(MappedReferenceValue));
    }

    protected Task<Result<int?>> TaskBindStructAsync(int value)
    {
        FuncExecuted = true;
        value.Should().Be(SourceStructValue);
        return Task.FromResult(Result.Ok<int?>(MappedStructValue));
    }

    protected ValueTask<Result<string?>> ValueTaskBindReferenceAsync(string value)
    {
        FuncExecuted = true;
        value.Should().Be(SourceReferenceValue);
        return ValueTask.FromResult(Result.Ok<string?>(MappedReferenceValue));
    }

    protected ValueTask<Result<int?>> ValueTaskBindStructAsync(int value)
    {
        FuncExecuted = true;
        value.Should().Be(SourceStructValue);
        return ValueTask.FromResult(Result.Ok<int?>(MappedStructValue));
    }

    protected void AssertSourceFailure<TValue>(Result<TValue?> output)
    {
        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == ErrorMessage);
        FuncExecuted.Should().BeFalse();
    }

    protected void AssertSkippedReference(Result<string?> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeNull();
        FuncExecuted.Should().BeFalse();
    }

    protected void AssertSkippedStruct(Result<int?> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().BeNull();
        FuncExecuted.Should().BeFalse();
    }

    protected void AssertMappedReference(Result<string?> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(MappedReferenceValue);
        FuncExecuted.Should().BeTrue();
    }

    protected void AssertMappedStruct(Result<int?> output)
    {
        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(MappedStructValue);
        FuncExecuted.Should().BeTrue();
    }
}
