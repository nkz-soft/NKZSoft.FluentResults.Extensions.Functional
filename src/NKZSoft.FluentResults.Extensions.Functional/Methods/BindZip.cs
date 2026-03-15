namespace NKZSoft.FluentResults.Extensions.Functional;

public static partial class ResultExtensions
{
    public static Result<(TValue First, TValueBind Second)> BindZip<TValue, TValueBind>(
        this Result<TValue> result,
        Func<TValue, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<(TValue, TValueBind)>(result.Errors);
        }

        var bindResult = func(result.Value);
        return bindResult.IsFailed
            ? Result.Fail<(TValue, TValueBind)>(bindResult.Errors)
            : Result.Ok((result.Value, bindResult.Value));
    }

    public static Result<(T1 First, T2 Second, TValueBind Third)> BindZip<T1, T2, TValueBind>(
        this Result<(T1, T2)> result,
        Func<T1, T2, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<(T1, T2, TValueBind)>(result.Errors);
        }

        var value = result.Value;
        var bindResult = func(value.Item1, value.Item2);
        return bindResult.IsFailed
            ? Result.Fail<(T1, T2, TValueBind)>(bindResult.Errors)
            : Result.Ok((value.Item1, value.Item2, bindResult.Value));
    }

    public static Result<(T1, T2, T3, TValueBind)> BindZip<T1, T2, T3, TValueBind>(
        this Result<(T1, T2, T3)> result,
        Func<T1, T2, T3, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<(T1, T2, T3, TValueBind)>(result.Errors);
        }

        var value = result.Value;
        var bindResult = func(value.Item1, value.Item2, value.Item3);
        return bindResult.IsFailed
            ? Result.Fail<(T1, T2, T3, TValueBind)>(bindResult.Errors)
            : Result.Ok((value.Item1, value.Item2, value.Item3, bindResult.Value));
    }

    public static Result<(T1, T2, T3, T4, TValueBind)> BindZip<T1, T2, T3, T4, TValueBind>(
        this Result<(T1, T2, T3, T4)> result,
        Func<T1, T2, T3, T4, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<(T1, T2, T3, T4, TValueBind)>(result.Errors);
        }

        var value = result.Value;
        var bindResult = func(value.Item1, value.Item2, value.Item3, value.Item4);
        return bindResult.IsFailed
            ? Result.Fail<(T1, T2, T3, T4, TValueBind)>(bindResult.Errors)
            : Result.Ok((value.Item1, value.Item2, value.Item3, value.Item4, bindResult.Value));
    }

    public static Result<(T1, T2, T3, T4, T5, TValueBind)> BindZip<T1, T2, T3, T4, T5, TValueBind>(
        this Result<(T1, T2, T3, T4, T5)> result,
        Func<T1, T2, T3, T4, T5, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<(T1, T2, T3, T4, T5, TValueBind)>(result.Errors);
        }

        var value = result.Value;
        var bindResult = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5);
        return bindResult.IsFailed
            ? Result.Fail<(T1, T2, T3, T4, T5, TValueBind)>(bindResult.Errors)
            : Result.Ok((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, bindResult.Value));
    }

    public static Result<(T1, T2, T3, T4, T5, T6, TValueBind)> BindZip<T1, T2, T3, T4, T5, T6, TValueBind>(
        this Result<(T1, T2, T3, T4, T5, T6)> result,
        Func<T1, T2, T3, T4, T5, T6, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<(T1, T2, T3, T4, T5, T6, TValueBind)>(result.Errors);
        }

        var value = result.Value;
        var bindResult = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6);
        return bindResult.IsFailed
            ? Result.Fail<(T1, T2, T3, T4, T5, T6, TValueBind)>(bindResult.Errors)
            : Result.Ok((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, bindResult.Value));
    }

    public static Result<(T1, T2, T3, T4, T5, T6, T7, TValueBind)> BindZip<T1, T2, T3, T4, T5, T6, T7, TValueBind>(
        this Result<(T1, T2, T3, T4, T5, T6, T7)> result,
        Func<T1, T2, T3, T4, T5, T6, T7, Result<TValueBind>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        if (result.IsFailed)
        {
            return Result.Fail<(T1, T2, T3, T4, T5, T6, T7, TValueBind)>(result.Errors);
        }

        var value = result.Value;
        var bindResult = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7);
        return bindResult.IsFailed
            ? Result.Fail<(T1, T2, T3, T4, T5, T6, T7, TValueBind)>(bindResult.Errors)
            : Result.Ok((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, bindResult.Value));
    }
}
