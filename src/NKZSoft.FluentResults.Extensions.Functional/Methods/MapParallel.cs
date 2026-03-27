namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    internal static Task<Result<IEnumerable<TValueOut>>> InternalMapParallelAsync<TValueIn, TValueOut>(
        IEnumerable<TValueIn> values,
        Func<TValueIn, Task<Result<TValueOut>>> map,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(values);
        ArgumentNullException.ThrowIfNull(map);

        return InternalMapParallelCoreAsync(values.ToArray(), map, maxDegreeOfParallelism, cancellationToken);
    }

    internal static ValueTask<Result<IEnumerable<TValueOut>>> InternalMapParallelAsync<TValueIn, TValueOut>(
        IEnumerable<TValueIn> values,
        Func<TValueIn, ValueTask<Result<TValueOut>>> map,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(values);
        ArgumentNullException.ThrowIfNull(map);

        return InternalMapParallelCoreAsync(values.ToArray(), map, maxDegreeOfParallelism, cancellationToken);
    }

    private static async Task<Result<IEnumerable<TValueOut>>> InternalMapParallelCoreAsync<TValueIn, TValueOut>(
        TValueIn[] values,
        Func<TValueIn, Task<Result<TValueOut>>> map,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        if (values.Length == 0)
        {
            return Result.Ok(Enumerable.Empty<TValueOut>());
        }

        var degree = ResolveParallelism(maxDegreeOfParallelism, values.Length);
        var resolved = new Result<TValueOut>[values.Length];
        var captured = new Exception?[values.Length];
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
                    if (index >= values.Length)
                    {
                        return;
                    }

                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        var mapped = await map(values[index]).WaitAsync(cancellationToken).ConfigureAwait(false);
                        ArgumentNullException.ThrowIfNull(mapped);
                        resolved[index] = mapped;
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

    private static async ValueTask<Result<IEnumerable<TValueOut>>> InternalMapParallelCoreAsync<TValueIn, TValueOut>(
        TValueIn[] values,
        Func<TValueIn, ValueTask<Result<TValueOut>>> map,
        int? maxDegreeOfParallelism,
        CancellationToken cancellationToken)
    {
        if (values.Length == 0)
        {
            return Result.Ok(Enumerable.Empty<TValueOut>());
        }

        var degree = ResolveParallelism(maxDegreeOfParallelism, values.Length);
        var resolved = new Result<TValueOut>[values.Length];
        var captured = new Exception?[values.Length];
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
                    if (index >= values.Length)
                    {
                        return;
                    }

                    cancellationToken.ThrowIfCancellationRequested();

                    try
                    {
                        var mapped = await map(values[index]).AsTask().WaitAsync(cancellationToken).ConfigureAwait(false);
                        ArgumentNullException.ThrowIfNull(mapped);
                        resolved[index] = mapped;
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
