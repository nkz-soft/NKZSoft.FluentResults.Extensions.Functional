namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    private static int ResolveParallelism(int? maxDegreeOfParallelism, int operationCount)
    {
        if (maxDegreeOfParallelism is <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism));
        }

        if (operationCount <= 0)
        {
            return 1;
        }

        var requested = maxDegreeOfParallelism ?? operationCount;
        return Math.Min(requested, operationCount);
    }

    internal static async Task<Result> InternalCombineParallelAsync(
        Task<Result>[] results,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(results);
        for (var i = 0; i < results.Length; i++)
        {
            ArgumentNullException.ThrowIfNull(results[i]);
        }

        if (results.Length == 0)
        {
            return Result.Ok();
        }

        var degree = ResolveParallelism(maxDegreeOfParallelism, results.Length);
        var resolved = new Result[results.Length];
        var captured = new Exception?[results.Length];
        var next = -1;
        var workers = new Task[degree];

        for (var w = 0; w < degree; w++)
        {
            workers[w] = Task.Run(async () =>
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var index = Interlocked.Increment(ref next);
                    if (index >= results.Length)
                    {
                        return;
                    }

                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        var value = await results[index].WaitAsync(cancellationToken).ConfigureAwait(false);
                        ArgumentNullException.ThrowIfNull(value);
                        resolved[index] = value;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        captured[index] = ex;
                    }
                }
            }, cancellationToken);
        }

        await Task.WhenAll(workers).ConfigureAwait(false);

        var exceptions = captured.Where(static ex => ex is not null).Cast<Exception>().ToArray();
        if (exceptions.Length > 0)
        {
            throw new AggregateException(exceptions);
        }

        return Combine(resolved);
    }

    internal static async Task<Result<IEnumerable<TValue>>> InternalCombineParallelAsync<TValue>(
        Task<Result<TValue>>[] results,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(results);
        for (var i = 0; i < results.Length; i++)
        {
            ArgumentNullException.ThrowIfNull(results[i]);
        }

        if (results.Length == 0)
        {
            return Result.Ok(Enumerable.Empty<TValue>());
        }

        var degree = ResolveParallelism(maxDegreeOfParallelism, results.Length);
        var resolved = new Result<TValue>[results.Length];
        var captured = new Exception?[results.Length];
        var next = -1;
        var workers = new Task[degree];

        for (var w = 0; w < degree; w++)
        {
            workers[w] = Task.Run(async () =>
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var index = Interlocked.Increment(ref next);
                    if (index >= results.Length)
                    {
                        return;
                    }

                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        var value = await results[index].WaitAsync(cancellationToken).ConfigureAwait(false);
                        ArgumentNullException.ThrowIfNull(value);
                        resolved[index] = value;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        captured[index] = ex;
                    }
                }
            }, cancellationToken);
        }

        await Task.WhenAll(workers).ConfigureAwait(false);

        var exceptions = captured.Where(static ex => ex is not null).Cast<Exception>().ToArray();
        if (exceptions.Length > 0)
        {
            throw new AggregateException(exceptions);
        }

        return Combine(resolved);
    }

    internal static async ValueTask<Result> InternalCombineParallelAsync(
        ValueTask<Result>[] results,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(results);

        if (results.Length == 0)
        {
            return Result.Ok();
        }

        var degree = ResolveParallelism(maxDegreeOfParallelism, results.Length);
        var resolved = new Result[results.Length];
        var captured = new Exception?[results.Length];
        var next = -1;
        var workers = new Task[degree];

        for (var w = 0; w < degree; w++)
        {
            workers[w] = Task.Run(async () =>
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var index = Interlocked.Increment(ref next);
                    if (index >= results.Length)
                    {
                        return;
                    }

                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        var value = await results[index].AsTask().WaitAsync(cancellationToken).ConfigureAwait(false);
                        ArgumentNullException.ThrowIfNull(value);
                        resolved[index] = value;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        captured[index] = ex;
                    }
                }
            }, cancellationToken);
        }

        await Task.WhenAll(workers).ConfigureAwait(false);

        var exceptions = captured.Where(static ex => ex is not null).Cast<Exception>().ToArray();
        if (exceptions.Length > 0)
        {
            throw new AggregateException(exceptions);
        }

        return Combine(resolved);
    }

    internal static async ValueTask<Result<IEnumerable<TValue>>> InternalCombineParallelAsync<TValue>(
        ValueTask<Result<TValue>>[] results,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(results);

        if (results.Length == 0)
        {
            return Result.Ok(Enumerable.Empty<TValue>());
        }

        var degree = ResolveParallelism(maxDegreeOfParallelism, results.Length);
        var resolved = new Result<TValue>[results.Length];
        var captured = new Exception?[results.Length];
        var next = -1;
        var workers = new Task[degree];

        for (var w = 0; w < degree; w++)
        {
            workers[w] = Task.Run(async () =>
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var index = Interlocked.Increment(ref next);
                    if (index >= results.Length)
                    {
                        return;
                    }

                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        var value = await results[index].AsTask().WaitAsync(cancellationToken).ConfigureAwait(false);
                        ArgumentNullException.ThrowIfNull(value);
                        resolved[index] = value;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        captured[index] = ex;
                    }
                }
            }, cancellationToken);
        }

        await Task.WhenAll(workers).ConfigureAwait(false);

        var exceptions = captured.Where(static ex => ex is not null).Cast<Exception>().ToArray();
        if (exceptions.Length > 0)
        {
            throw new AggregateException(exceptions);
        }

        return Combine(resolved);
    }
}
