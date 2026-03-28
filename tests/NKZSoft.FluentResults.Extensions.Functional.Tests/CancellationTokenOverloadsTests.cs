namespace NKZSoft.FluentResults.Extensions.Functional.Tests;

public sealed class CancellationTokenOverloadsTests
{
    [Test]
    public async Task MapAsyncWithCancellationTokenForwardsToken()
    {
        var cts = new CancellationTokenSource();
        var forwarded = CancellationToken.None;

        var output = await Result.Ok(5).MapAsync(
            static (value, token) =>
            {
                token.ThrowIfCancellationRequested();
                return Task.FromResult(value + 1);
            },
            cts.Token);

        await Result.Ok().MapAsync(
            token =>
            {
                forwarded = token;
                return Task.FromResult(1);
            },
            cts.Token);

        output.IsSuccess.Should().BeTrue();
        output.Value.Should().Be(6);
        forwarded.Should().Be(cts.Token);
    }

    [Test]
    public async Task BindAndBindTryWithCancellationTokenForwardsToken()
    {
        var cts = new CancellationTokenSource();
        CancellationToken bindToken = default;
        CancellationToken bindTryToken = default;

        await Result.Ok(5).BindAsync(
            (value, token) =>
            {
                bindToken = token;
                return Task.FromResult(Result.Ok(value));
            },
            cts.Token);

        await Result.Ok(5).BindTryAsync(
            (value, token) =>
            {
                bindTryToken = token;
                return Task.FromResult(Result.Ok(value));
            },
            cancellationToken: cts.Token);

        bindToken.Should().Be(cts.Token);
        bindTryToken.Should().Be(cts.Token);
    }

    [Test]
    public async Task TapAndTapTryWithCancellationTokenForwardsToken()
    {
        var cts = new CancellationTokenSource();
        CancellationToken tapToken = default;
        CancellationToken tapTryToken = default;

        await Result.Ok(5).TapAsync(
            (value, token) =>
            {
                tapToken = token;
                return Task.CompletedTask;
            },
            cts.Token);

        await Result.Ok(5).TapTryAsync(
            (value, token) =>
            {
                tapTryToken = token;
                return Task.CompletedTask;
            },
            cancellationToken: cts.Token);

        tapToken.Should().Be(cts.Token);
        tapTryToken.Should().Be(cts.Token);
    }

    [Test]
    public async Task TapIfTapIfTryCheckAndCheckIfWithCancellationTokenForwardsToken()
    {
        var cts = new CancellationTokenSource();
        CancellationToken tapIfToken = default;
        CancellationToken tapIfTryToken = default;
        CancellationToken checkToken = default;
        CancellationToken checkIfToken = default;

        await Result.Ok(5).TapIfAsync(value => value > 0,
            (value, token) =>
            {
                tapIfToken = token;
                return Task.CompletedTask;
            },
            cts.Token);

        await Result.Ok(5).TapIfTryAsync(value => value > 0,
            (value, token) =>
            {
                tapIfTryToken = token;
                return Task.CompletedTask;
            },
            cancellationToken: cts.Token);

        await Result.Ok(5).CheckAsync(
            (value, token) =>
            {
                checkToken = token;
                return Task.FromResult(Result.Ok());
            },
            cts.Token);

        await Result.Ok(5).CheckIfAsync(
            true,
            (value, token) =>
            {
                checkIfToken = token;
                return Task.FromResult(Result.Ok());
            },
            cts.Token);

        tapIfToken.Should().Be(cts.Token);
        tapIfTryToken.Should().Be(cts.Token);
        checkToken.Should().Be(cts.Token);
        checkIfToken.Should().Be(cts.Token);
    }

    [Test]
    public async Task EnsureWithCancellationTokenForwardsToken()
    {
        var cts = new CancellationTokenSource();
        CancellationToken ensureToken = default;

        var output = await Result.Ok(5).EnsureAsync(
            (value, token) =>
            {
                ensureToken = token;
                return Task.FromResult(value > 0);
            },
            "failed",
            cts.Token);

        output.IsSuccess.Should().BeTrue();
        ensureToken.Should().Be(cts.Token);
    }

    [Test]
    public async Task TryAsyncWithCancellationTokenHandlesCancellation()
    {
        var cts = new CancellationTokenSource();
        cts.Cancel();

        var output = await ResultExtensions.TryAsync(
            token =>
            {
                token.ThrowIfCancellationRequested();
                return Task.CompletedTask;
            },
            exception => exception.GetType().Name,
            cts.Token);

        output.IsFailed.Should().BeTrue();
        output.Errors.Should().ContainSingle(error => error.Message == nameof(OperationCanceledException));
    }

    [Test]
    public async Task CombineCompleteAndFirstFailureSupportCancellationToken()
    {
        var outputCombine = await ResultExtensions.CombineInOrderAsync([Task.FromResult(Result.Ok())], CancellationToken.None);
        var outputComplete = await ResultExtensions.CompleteInOrderAsync([Task.FromResult(Result.Ok())], CancellationToken.None);
        var outputFirst = await ResultExtensions.FirstFailureOrSuccessAsync([Task.FromResult(Result.Ok())], CancellationToken.None);

        outputCombine.IsSuccess.Should().BeTrue();
        outputComplete.IsSuccess.Should().BeTrue();
        outputFirst.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineAndCompleteParallelSupportCancellationToken()
    {
        var outputCombine = await ResultExtensions.CombineParallelAsync([Task.FromResult(Result.Ok())], cancellationToken: CancellationToken.None);
        var outputComplete = await ResultExtensions.CompleteParallelAsync([Task.FromResult(Result.Ok())], cancellationToken: CancellationToken.None);

        outputCombine.IsSuccess.Should().BeTrue();
        outputComplete.IsSuccess.Should().BeTrue();
    }

    [Test]
    public async Task CombineAndCompleteParallelThrowWhenCancellationIsPreRequested()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var combineAction = async () => await ResultExtensions.CombineParallelAsync(
            [Task.FromResult(Result.Ok())],
            cancellationToken: cts.Token);

        var completeAction = async () => await ResultExtensions.CompleteParallelAsync(
            [Task.FromResult(Result.Ok())],
            cancellationToken: cts.Token);

        await combineAction.Should().ThrowAsync<OperationCanceledException>();
        await completeAction.Should().ThrowAsync<OperationCanceledException>();
    }
}
