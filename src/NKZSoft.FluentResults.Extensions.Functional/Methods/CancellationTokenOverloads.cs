namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Adds a cancellation-aware overload for <c>MapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValue>> MapAsync<TValue>(
        this Result result,
        Func<CancellationToken, Task<TValue>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.MapAsync(() => func(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>MapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValue>> MapAsync<TValue>(
        this Result result,
        Func<CancellationToken, ValueTask<TValue>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.MapAsync(() => func(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>MapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <typeparam name="TValueOut">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, Task<TValueOut>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.MapAsync(value => func(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>MapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <typeparam name="TValueOut">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValueOut>> MapAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, ValueTask<TValueOut>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.MapAsync(value => func(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>MapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="resultTask">The source asynchronous result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result<TValue>> MapAsync<TValue>(
        this Task<Result> resultTask,
        Func<CancellationToken, Task<TValue>> func,
        CancellationToken cancellationToken = default)
    {
        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>MapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="resultTask">The source asynchronous result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result<TValue>> MapAsync<TValue>(
        this ValueTask<Result> resultTask,
        Func<CancellationToken, ValueTask<TValue>> func,
        CancellationToken cancellationToken = default)
    {
        var result = await resultTask.ConfigureAwait(false);
        return await result.MapAsync(func, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result> BindAsync(
        this Result result,
        Func<CancellationToken, Task<Result>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindAsync(() => func(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result> BindAsync(
        this Result result,
        Func<CancellationToken, ValueTask<Result>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindAsync(() => func(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValue>> BindAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, Task<Result<TValue>>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindAsync(value => func(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValue>> BindAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, ValueTask<Result<TValue>>> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindAsync(value => func(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="resultTask">The source asynchronous result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result> BindAsync(
        this Task<Result> resultTask,
        Func<CancellationToken, Task<Result>> func,
        CancellationToken cancellationToken = default)
    {
        var result = await resultTask.ConfigureAwait(false);
        return await result.BindAsync(func, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="resultTask">The source asynchronous result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result> BindAsync(
        this ValueTask<Result> resultTask,
        Func<CancellationToken, ValueTask<Result>> func,
        CancellationToken cancellationToken = default)
    {
        var result = await resultTask.ConfigureAwait(false);
        return await result.BindAsync(func, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result> BindTryAsync(
        this Result result,
        Func<CancellationToken, Task<Result>> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindTryAsync(() => func(cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result> BindTryAsync(
        this Result result,
        Func<CancellationToken, ValueTask<Result>> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindTryAsync(() => func(cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <typeparam name="TValueOut">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, Task<Result<TValueOut>>> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindTryAsync(value => func(value, cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>BindTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <typeparam name="TValueOut">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValueOut>> BindTryAsync<TValue, TValueOut>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, ValueTask<Result<TValueOut>>> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.BindTryAsync(value => func(value, cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result> TapAsync(
        this Result result,
        Func<CancellationToken, Task> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapAsync(() => func(cancellationToken)).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result> TapAsync(
        this Result result,
        Func<CancellationToken, ValueTask> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapAsync(() => func(cancellationToken)).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result<TValue>> TapAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, Task> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapAsync(value => func(value, cancellationToken)).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result<TValue>> TapAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, ValueTask> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapAsync(value => func(value, cancellationToken)).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result> TapTryAsync(
        this Result result,
        Func<CancellationToken, Task> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapTryAsync(() => func(cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result> TapTryAsync(
        this Result result,
        Func<CancellationToken, ValueTask> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapTryAsync(() => func(cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result<TValue>> TapTryAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, Task> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapTryAsync(value => func(value, cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result<TValue>> TapTryAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, ValueTask> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await result.TapTryAsync(value => func(value, cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls execution.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result> TapIfAsync(
        this Result result,
        bool condition,
        Func<CancellationToken, Task> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfAsync(condition, () => func(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls execution.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result> TapIfAsync(
        this Result result,
        bool condition,
        Func<CancellationToken, ValueTask> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfAsync(condition, () => func(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate delegate to evaluate.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValue>> TapIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, CancellationToken, Task> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfAsync(predicate, value => func(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate delegate to evaluate.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValue>> TapIfAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, CancellationToken, ValueTask> func,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfAsync(predicate, value => func(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls execution.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result> TapIfTryAsync(
        this Result result,
        bool condition,
        Func<CancellationToken, Task> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfTryAsync(condition, () => func(cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls execution.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result> TapIfTryAsync(
        this Result result,
        bool condition,
        Func<CancellationToken, ValueTask> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfTryAsync(condition, () => func(cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate delegate to evaluate.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValue>> TapIfTryAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, CancellationToken, Task> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfTryAsync(predicate, value => func(value, cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TapIfTryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate delegate to evaluate.</param>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValue>> TapIfTryAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, bool> predicate,
        Func<TValue, CancellationToken, ValueTask> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(func);
        return result.TapIfTryAsync(predicate, value => func(value, cancellationToken), errorHandler);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CheckAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="check">The check delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result> CheckAsync(
        this Result result,
        Func<CancellationToken, Task<Result>> check,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(check);
        return result.CheckAsync(() => check(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CheckAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="result">The source result.</param>
    /// <param name="check">The check delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result> CheckAsync(
        this Result result,
        Func<CancellationToken, ValueTask<Result>> check,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(check);
        return result.CheckAsync(() => check(cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CheckAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="check">The check delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValue>> CheckAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, Task<Result>> check,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(check);
        return result.CheckAsync(value => check(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CheckAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="check">The check delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValue>> CheckAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, ValueTask<Result>> check,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(check);
        return result.CheckAsync(value => check(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CheckIfAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls execution.</param>
    /// <param name="check">The check delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<TValue, CancellationToken, Task<Result>> check,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(check);
        return result.CheckIfAsync(condition, value => check(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CheckIfAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="condition">The condition that controls execution.</param>
    /// <param name="check">The check delegate to execute.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValue>> CheckIfAsync<TValue>(
        this Result<TValue> result,
        bool condition,
        Func<TValue, CancellationToken, ValueTask<Result>> check,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(check);
        return result.CheckIfAsync(condition, value => check(value, cancellationToken));
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>EnsureAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate delegate to evaluate.</param>
    /// <param name="errorMessage">The error message to use when validation fails.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result<TValue>> EnsureAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, Task<bool>> predicate,
        string errorMessage,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return result.EnsureAsync(value => predicate(value, cancellationToken), errorMessage);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>EnsureAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="result">The source result.</param>
    /// <param name="predicate">The predicate delegate to evaluate.</param>
    /// <param name="errorMessage">The error message to use when validation fails.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result<TValue>> EnsureAsync<TValue>(
        this Result<TValue> result,
        Func<TValue, CancellationToken, ValueTask<bool>> predicate,
        string errorMessage,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return result.EnsureAsync(value => predicate(value, cancellationToken), errorMessage);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="action">The action delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result> TryAsync(
        Func<CancellationToken, Task> action,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(action);
        return await TryAsync(() => action(cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="action">The action delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result> TryAsync(
        Func<CancellationToken, ValueTask> action,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(action);
        return await TryAsync(() => action(cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result<TValue>> TryAsync<TValue>(
        Func<CancellationToken, Task<TValue>> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await TryAsync(() => func(cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>TryAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <typeparam name="TValue">The type parameter for this overload.</typeparam>
    /// <param name="func">The delegate to execute.</param>
    /// <param name="errorHandler">An optional exception-to-error mapper.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result<TValue>> TryAsync<TValue>(
        Func<CancellationToken, ValueTask<TValue>> func,
        Func<Exception, string>? errorHandler = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(func);
        return await TryAsync(() => func(cancellationToken), errorHandler).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CombineInOrderAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="results">The asynchronous results to process in order.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result> CombineInOrderAsync(
        Task<Result>[] results,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(results);
        var resolved = new Result[results.Length];
        for (var i = 0; i < results.Length; i++)
        {
            ArgumentNullException.ThrowIfNull(results[i]);
            resolved[i] = await results[i].WaitAsync(cancellationToken).ConfigureAwait(false);
            ArgumentNullException.ThrowIfNull(resolved[i]);
        }

        return CombineInOrder(resolved);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CombineInOrderAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="results">The asynchronous results to process in order.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result> CombineInOrderAsync(
        ValueTask<Result>[] results,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(results);
        var resolved = new Result[results.Length];
        for (var i = 0; i < results.Length; i++)
        {
            resolved[i] = await results[i].AsTask().WaitAsync(cancellationToken).ConfigureAwait(false);
            ArgumentNullException.ThrowIfNull(resolved[i]);
        }

        return CombineInOrder(resolved);
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CompleteInOrderAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="results">The asynchronous results to process in order.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static Task<Result> CompleteInOrderAsync(
        Task<Result>[] results,
        CancellationToken cancellationToken = default)
        => CombineInOrderAsync(results, cancellationToken);

    /// <summary>
    /// Adds a cancellation-aware overload for <c>CompleteInOrderAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="results">The asynchronous results to process in order.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static ValueTask<Result> CompleteInOrderAsync(
        ValueTask<Result>[] results,
        CancellationToken cancellationToken = default)
        => CombineInOrderAsync(results, cancellationToken);

    /// <summary>
    /// Adds a cancellation-aware overload for <c>FirstFailureOrSuccessAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="results">The asynchronous results to process in order.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A task containing the operation result.</returns>
    public static async Task<Result> FirstFailureOrSuccessAsync(
        Task<Result>[] results,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(results);

        foreach (var resultTask in results)
        {
            ArgumentNullException.ThrowIfNull(resultTask);
            var result = await resultTask.WaitAsync(cancellationToken).ConfigureAwait(false);
            if (result.IsFailed)
            {
                return result;
            }
        }

        return Result.Ok();
    }

    /// <summary>
    /// Adds a cancellation-aware overload for <c>FirstFailureOrSuccessAsync</c> that forwards <paramref name="cancellationToken"/> to the provided delegate.
    /// </summary>
    /// <param name="results">The asynchronous results to process in order.</param>
    /// <param name="cancellationToken">The cancellation token forwarded to the delegate.</param>
    /// <returns>A value task containing the operation result.</returns>
    public static async ValueTask<Result> FirstFailureOrSuccessAsync(
        ValueTask<Result>[] results,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(results);

        foreach (var resultTask in results)
        {
            var result = await resultTask.AsTask().WaitAsync(cancellationToken).ConfigureAwait(false);
            if (result.IsFailed)
            {
                return result;
            }
        }

        return Result.Ok();
    }
}
