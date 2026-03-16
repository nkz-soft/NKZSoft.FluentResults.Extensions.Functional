# NKZSoft.FluentResults.Functional.Extensions

![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/nkz-soft/NKZSoft.FluentResults.Extensions.Functional?style=flat-square)
![license](https://img.shields.io/github/license/nkz-soft/NKZSoft.FluentResults.Extensions.Functional?style=flat-square)
![GitHub Workflow Status (with branch)](https://img.shields.io/github/actions/workflow/status/nkz-soft/NKZSoft.FluentResults.Extensions.Functional/build.yaml)
[![coverage](https://gist.githubusercontent.com/nkz-soft/d24d45d2f634d03f790e3656b3024e44/raw/coverage.svg)](https://github.com/nkz-soft/NKZSoft.FluentResults.Extensions.Functional/actions/workflows/build.yaml)

It is a library that extends the popular [FluentResults](https://github.com/altmann/FluentResults) library and helps you write code in a more functional way.
The project was inspired by [Functional Extensions for C#](https://github.com/vkhorikov/CSharpFunctionalExtensions).

### ⭐ Give a star

If you're using this repository for your learning, samples or your project, please give a star. Thanks :+1:

## Installation

Available on [NuGet](https://www.nuget.org/packages/NKZSoft.FluentResults.Extensions.Functional/)

```bash
dotnet add package NKZSoft.FluentResults.Extensions.Functional
```

## Testing

The test project uses [TUnit](https://tunit.dev/).

```bash
dotnet test NKZSoft.FluentResults.Extensions.Functional.sln
```

## Features
All methods have asynchronous overloads and ValueTask support.

<details>
<summary><strong>Bind</strong></summary>

It executes the function only if the Result is successful (i.e., not failed). If the Result is failed, it returns the original failed Result. 
If the Result is successful, it executes the function and returns the resulting Result.

```csharp
public async Task<Result<int>> OnSuccessAsync(int x)
...
await Result.Ok(1).BindAsync(OnSuccessAsync);
```

</details>

<details>
<summary><strong>Finally</strong></summary>

Executes a function after a Result, regardless of its success or failure.

```csharp
public async Task<int> OnBothAsync(Result result)
...
await Result.Ok().FinallyAsync(OnBothAsync);
```

</details>

<details>
<summary><strong>BindIf</strong></summary>

Conditionally executes `Bind` logic.
If the condition/predicate is not satisfied, it returns the original result unchanged.

```csharp
var output = Result.Ok(10)
    .BindIf(true, value => Result.Ok(value + 5));

var output2 = Result.Ok(10)
    .BindIf(value => value > 5, value => Result.Ok(value * 2));

public Task<Result<int>> IncrementAsync(int value)
...
var output3 = await Result.Ok(10)
    .BindIfAsync(value => value > 5, IncrementAsync);

var output4 = await GetNumberAsync()
    .BindIfAsync(true, value => ValueTask.FromResult(Result.Ok(value * 3)));
```

</details>

<details>
<summary><strong>BindTry</strong></summary>

Executes `Bind` logic for successful results and converts thrown exceptions into failed results.
If the source result is already failed, the original failure is preserved and the delegate is not executed.

```csharp
var output = Result.Ok(10)
    .BindTry(value => Result.Ok(value + 5));

var output2 = Result.Ok(10)
    .BindTry(
        value => Result.Ok(int.Parse(value.ToString())),
        ex => $"Bind failed: {ex.Message}");

public Task<Result<int>> IncrementAsync(int value)
...
var output3 = await Result.Ok(10)
    .BindTryAsync(IncrementAsync);

var output4 = await GetNumberAsync()
    .BindTryAsync(value => ValueTask.FromResult(Result.Ok(value * 3)));
```

</details>

<details>
<summary><strong>BindOptional</strong></summary>

Conditionally executes bind logic for nullable result values.
If the source result is failed, the failure is preserved.
If the source result is successful and the value is `null`, the delegate is skipped and a successful `null` result is returned.

```csharp
var output = Result.Ok<string?>("alice")
    .BindOptional(name => Result.Ok<string?>($"{name}@example.com"));

var output2 = Result.Ok<string?>(null)
    .BindOptional(name => Result.Ok<string?>($"{name}@example.com"));

public Task<Result<int?>> DoubleAsync(int value)
...
var output3 = await Result.Ok<int?>(21)
    .BindOptionalAsync(DoubleAsync);

var output4 = await GetNullableNameAsync()
    .BindOptionalAsync(name => ValueTask.FromResult(Result.Ok<string?>($"user:{name}")));
```

</details>

<details>
<summary><strong>BindZip</strong></summary>

Binds a successful result and appends the newly produced value to the existing successful value tuple.
This is useful when you want to keep previous successful values in a pipeline instead of projecting them away.

```csharp
var output = Result.Ok(user)
    .BindZip(u => GetAccount(u));
// Result<(User user, Account account)>

var output2 = Result.Ok(user)
    .BindZip(u => GetAccount(u))
    .BindZip((u, account) => GetSubscription(u, account));
// Result<(User user, Account account, Subscription subscription)>

var output3 = await GetUserAsync()
    .BindZipAsync(u => GetAccountAsync(u));
```

</details>

<details>
<summary><strong>Tap</strong></summary>

Executes an action if the result is successful and return the original result.

```csharp
public async Task OnActionAsync()
...
await Result.Ok().TapAsync(OnActionAsync);

public ValueTask OnActionValueTaskAsync()
...
await Result.Ok().TapAsync(OnActionValueTaskAsync);

public Task<Result> GetResultAsync()
...
await GetResultAsync().TapAsync(OnActionValueTaskAsync);
```

</details>

<details>
<summary><strong>TapIf</strong></summary>

Conditionally executes `Tap` logic.
If the condition or predicate is not satisfied, it returns the original result unchanged.

```csharp
var output = Result.Ok(10)
    .TapIf(true, () => Log("ok"));

var output2 = Result.Ok(10)
    .TapIf(value => value > 5, value => Audit(value));

public Task NotifyAsync(int value)
...
var output3 = await Result.Ok(10)
    .TapIfAsync(value => value > 5, NotifyAsync);

var output4 = await GetNumberAsync()
    .TapIfAsync(true, value => ValueTask.CompletedTask);
```

</details>

<details>
<summary><strong>Match</strong></summary>

Matches a Result to either a success or failure action.

```csharp
public async Task OnSuccessAsync()
...
public async Task OnFailureAsync(IReadOnlyList<IError> errors)
...

await Result.Ok().MatchAsync(OnActionAsync, OnFailureAsync);
```

</details>

<details>
<summary><strong>Ensure</strong></summary>

Ensures that a condition is met for a successful Result.
If the condition is not met, returns a failed Result with the specified error message.

```csharp
var outputResult = await result.EnsureAsync(() => true, FailErrorMessage);
```

For `Result<TValue>`, `Ensure` also supports value-aware predicates and result predicates:

```csharp
var output1 = Result.Ok(user)
    .Ensure(u => !string.IsNullOrWhiteSpace(u.Email), "Email is required");

var output2 = Result.Ok(user)
    .Ensure(u => u.IsActive ? Result.Ok() : Result.Fail("User is inactive"));

var output3 = await Result.Ok(user)
    .EnsureAsync(u => Task.FromResult(u.Age >= 18), "User must be 18+");
```

These overloads are available for sync, `Task`, and `ValueTask` variants (left/right/both async forms).

</details>

<details>
<summary><strong>SuccessIf</strong></summary>

`SuccessIf` provides CSharpFunctionalExtensions-style naming for FluentResults `OkIf` behavior.

```csharp
var output = ResultExtensions.SuccessIf(amount > 0, "Amount must be positive");

var outputWithValue = ResultExtensions.SuccessIf(
    () => amount > 0,
    amount,
    "Amount must be positive");

var asyncOutput = await ResultExtensions.SuccessIfAsync(
    async () => await IsAmountValidAsync(amount),
    "Amount must be positive");
```

</details>

<details>
<summary><strong>FailureIf</strong></summary>

`FailureIf` provides CSharpFunctionalExtensions-style inverted condition naming.
It fails when the condition/predicate is `true`.

```csharp
var output = ResultExtensions.FailureIf(amount <= 0, "Amount must be positive");

var outputWithValue = ResultExtensions.FailureIf(
    () => amount <= 0,
    amount,
    "Amount must be positive");

var asyncOutput = await ResultExtensions.FailureIfAsync(
    async () => await IsAmountInvalidAsync(amount),
    "Amount must be positive");
```

</details>

<details>
<summary><strong>Combine</strong></summary>

`Combine` provides CSharpFunctionalExtensions-style naming over FluentResults `Merge`.
It aggregates reasons from all input results and returns success only when all inputs are successful.

```csharp
var output = ResultExtensions.Combine(
    Result.Ok(),
    Result.Fail("Validation failed"),
    Result.Fail("Another error"));

var outputWithValues = ResultExtensions.Combine(
    Result.Ok(1),
    Result.Ok(2));

var asyncOutput = await ResultExtensions.CombineAsync(
    Task.FromResult(Result.Ok()),
    Task.FromResult(Result.Fail("Validation failed")));
```

</details>

<details>
<summary><strong>CombineInOrder</strong></summary>

`CombineInOrder` provides CSharpFunctionalExtensions-style naming for ordered async result combination.
For synchronous inputs, behavior matches `Combine`.
For async (`Task`/`ValueTask`) inputs, results are awaited in input order before aggregation.

```csharp
var output = ResultExtensions.CombineInOrder(
    Result.Ok(),
    Result.Fail("Validation failed"),
    Result.Fail("Another error"));

var outputWithValues = ResultExtensions.CombineInOrder(
    Result.Ok(1),
    Result.Ok(2));

var asyncOutput = await ResultExtensions.CombineInOrderAsync(
    Task.FromResult(Result.Ok()),
    Task.FromResult(Result.Fail("Validation failed")));
```

</details>

<details>
<summary><strong>CompleteInOrder</strong></summary>

`CompleteInOrder` is an alias over `CombineInOrder` for ordered async result completion.
For synchronous inputs, behavior matches `Combine`/`CombineInOrder`.
For async (`Task`/`ValueTask`) inputs, results are awaited in input order before aggregation.

```csharp
var output = ResultExtensions.CompleteInOrder(
    Result.Ok(),
    Result.Fail("Validation failed"),
    Result.Fail("Another error"));

var outputWithValues = ResultExtensions.CompleteInOrder(
    Result.Ok(1),
    Result.Ok(2));

var asyncOutput = await ResultExtensions.CompleteInOrderAsync(
    Task.FromResult(Result.Ok()),
    Task.FromResult(Result.Fail("Validation failed")));
```

</details>

<details>
<summary><strong>FirstFailureOrSuccess</strong></summary>

`FirstFailureOrSuccess` provides CSharpFunctionalExtensions-style short-circuit failure selection.
It returns the first failed `Result` from the provided sequence or `Result.Ok()` when all results are successful.
This differs from FluentResults `Merge`, which aggregates reasons from all results.

```csharp
var output = ResultExtensions.FirstFailureOrSuccess(
    Result.Ok(),
    Result.Fail("Validation failed"),
    Result.Fail("Will not be returned"));

var asyncOutput = await ResultExtensions.FirstFailureOrSuccessAsync(
    Task.FromResult(Result.Ok()),
    Task.FromResult(Result.Fail("Validation failed")));
```

</details>

<details>
<summary><strong>EnsureNot</strong></summary>

`EnsureNot` provides CSharpFunctionalExtensions-style inverted predicate checks for `Result<TValue>`.
It fails when the predicate evaluates to `true`.

```csharp
var output = Result.Ok(15)
    .EnsureNot(x => x > 10, "Value should be less than or equal to 10");

Task<Result<int>> maybeAmountTask = GetAmountAsync();
Result<int> ensuredFromTask = await maybeAmountTask
    .EnsureNotAsync(x => x > 10, "Value should be less than or equal to 10");
```

</details>

<details>
<summary><strong>Required</strong></summary>

Requires a successful result value to be non-null.
If the source result is failed, errors are preserved.

```csharp
Result<string?> maybeName = Result.Ok<string?>(null);
Result<string> requiredName = maybeName.Required("Name is required");

Task<Result<string?>> maybeNameTask = GetNameAsync();
Result<string> requiredFromTask = await maybeNameTask.RequiredAsync("Name is required");
```

</details>

<details>
<summary><strong>EnsureNotNull</strong></summary>

`EnsureNotNull` provides CSharpFunctionalExtensions-style naming for non-null validation and follows the same behavior as `Required`.

```csharp
Result<string?> maybeEmail = Result.Ok<string?>(null);
Result<string> ensuredEmail = maybeEmail.EnsureNotNull("Email is required");

Task<Result<string?>> maybeEmailTask = GetEmailAsync();
Result<string> ensuredFromTask = await maybeEmailTask.EnsureNotNullAsync("Email is required");
```

</details>

<details>
<summary><strong>Try</strong></summary>

Executes code and converts thrown exceptions to failed `Result` values.

```csharp
var saveResult = ResultExtensions.Try(() => Save(customer));

var loadResult = await ResultExtensions.TryAsync(
    async () => await repository.LoadAsync(id),
    ex => $"Load failed: {ex.Message}");
```

</details>

<details>
<summary><strong>OnSuccessTry</strong></summary>

Executes an action/function only for successful results and converts thrown exceptions into failed `Result` values.
For failed source results, errors are preserved and the delegate is not executed.

```csharp
var output = Result.Ok()
    .OnSuccessTry(() => Save(customer));

var outputWithValue = Result.Ok(customer)
    .OnSuccessTry(c => SendNotification(c));

var asyncOutput = await GetCustomerResultAsync()
    .OnSuccessTryAsync(async c => await SendNotificationAsync(c));
```

</details>

<details>
<summary><strong>Compensate</strong></summary>

Recovers from failure by executing a fallback function only when the source result is failed.
For successful source results, the original result instance is returned unchanged.

```csharp
var recovered = Result.Fail("Validation failed")
    .Compensate(() => Result.Ok());

var recoveredWithErrors = Result.Fail<int>("Validation failed")
    .Compensate(errors => Result.Ok(42));

var asyncRecovered = await GetCustomerResultAsync()
    .CompensateAsync(errors => RecoverCustomerAsync(errors));
```

</details>

<details>
<summary><strong>OnFailureCompensate</strong></summary>

`OnFailureCompensate` is a CSharpFunctionalExtensions-style alias for `Compensate`.
It executes fallback logic only when the source result is failed.

```csharp
var recovered = Result.Fail("Validation failed")
    .OnFailureCompensate(() => Result.Ok());

var recoveredWithValue = Result.Fail<int>("Validation failed")
    .OnFailureCompensate(errors => Result.Ok(42));

var asyncRecovered = await GetCustomerResultAsync()
    .OnFailureCompensateAsync(errors => RecoverCustomerAsync(errors));
```

</details>

<details>
<summary><strong>Of</strong></summary>

Creates successful results from values and value-producing delegates.
Unlike `Try`, exceptions are not converted to failure results and are propagated to the caller.

```csharp
var fromValue = ResultExtensions.Of(42);

var fromFunc = ResultExtensions.Of(() => ComputeValue());

var fromTask = await ResultExtensions.OfAsync(repository.GetByIdAsync(id));

var fromValueTask = await ResultExtensions.OfAsync(GetValueValueTaskAsync);
```

</details>

<details>
<summary><strong>Check</strong></summary>

Executes a function only if the Result is successful, acting as a validation step in a chain.
If the function returns failure, the failure is returned; otherwise it returns the original result.

```csharp
public Task<Result> EnsureUniqueEmailAsync(string email)
...
var output = await GetUserAsync()
    .CheckAsync(user => EnsureUniqueEmailAsync(user.Email))
    .BindAsync(SaveAsync);
```

</details>

<details>
<summary><strong>CheckIf</strong></summary>

Conditionally executes `Check` logic for `Result<TValue>`.
If the condition/predicate is not satisfied, it returns the original result unchanged.

```csharp
var output = Result.Ok(user)
    .CheckIf(user.IsActive, u => EnsureUniqueEmailAsync(u.Email));

var output2 = await GetUserAsync()
    .CheckIfAsync(u => u.IsActive, u => EnsureUniqueEmailAsync(u.Email));
```

</details>

<details>
<summary><strong>Map</strong></summary>

Creates a new Result from the return value of a function.
If the Result is failed, returns a failed Result with the same errors.

```csharp
public async Task<Dto> MapAsync(int value)
...
var output = await Result.Ok(1).MapAsync(MapAsync);

public ValueTask<Dto> MapValueTaskAsync(int value)
...
var output2 = await Result.Ok(1).MapAsync(MapValueTaskAsync);

public Task<Result<int>> GetNumberAsync()
...
var output3 = await GetNumberAsync().MapAsync(MapValueTaskAsync);
```

</details>

<details>
<summary><strong>MapIf</strong></summary>

Conditionally maps a successful `Result<TValue>`.
If the condition or predicate is not satisfied, it returns the original result unchanged.

```csharp
var output = Result.Ok(10)
    .MapIf(true, value => value + 5);

var output2 = Result.Ok(10)
    .MapIf(value => value > 5, value => value * 2);

public Task<int> IncrementAsync(int value)
...
var output3 = await Result.Ok(10)
    .MapIfAsync(value => value > 5, IncrementAsync);

var output4 = await GetNumberAsync()
    .MapIfAsync(true, value => ValueTask.FromResult(value * 3));
```

</details>

<details>
<summary><strong>MapError</strong></summary>

`MapError` provides CSharpFunctionalExtensions-style naming over FluentResults `MapErrors`.
Because FluentResults supports multiple `IError` values, `MapError` maps every error in a failed result and returns successful results unchanged.

```csharp
var output = Result.Fail("Validation failed")
    .MapError(error => new Error($"Mapped: {error.Message}"));

var outputWithValue = Result.Fail<int>("Validation failed")
    .MapError(error => new Error($"Mapped: {error.Message}"));

public Task<IError> MapErrorAsync(IError error)
...
var asyncOutput = await GetResultAsync()
    .MapErrorAsync(MapErrorAsync);
```

</details>

<details>
<summary><strong>MapTry</strong></summary>

Creates a new Result from the return value of a function and converts thrown exceptions into failed Results.
If the source Result is failed, its errors are preserved and the delegate is not executed.

```csharp
var output = Result.Ok(1)
    .MapTry(value => int.Parse(value.ToString()));

var outputWithCustomError = Result.Ok("42")
    .MapTry(value => int.Parse(value), ex => $"Parsing failed: {ex.Message}");

public Task<int> LoadNumberAsync()
...
var outputAsync = await Result.Ok()
    .MapTryAsync(LoadNumberAsync);

var outputFromTask = await GetNumberAsync()
    .MapTryAsync(value => ValueTask.FromResult(value + 1));
```

</details>

<details>
<summary><strong>Select</strong></summary>

LINQ-friendly alias for `Map`.
If the Result is failed, returns a failed Result with the same errors.

```csharp
var output = Result.Ok(1).Select(v => v + 1);

public Task<Result<int>> GetNumberAsync()
...
var output2 = await GetNumberAsync().SelectAsync(v => v + 1);
```

</details>

<details>
<summary><strong>GetValueOrDefault</strong></summary>

Returns the successful value from `Result<TValue>` or a fallback when the result is failed.
Includes selector overloads and async variants for `Task<Result<TValue>>` / `ValueTask<Result<TValue>>`.

```csharp
Result<int> amountResult = Result.Ok(10);
int amount = amountResult.GetValueOrDefault(0);

Result<int> failedAmountResult = Result.Fail<int>("Amount is missing");
int amountWithFallback = failedAmountResult.GetValueOrDefault(() => 0);

string text = failedAmountResult.GetValueOrDefault(
    value => value.ToString(),
    () => "N/A");

Task<Result<int>> amountTask = GetAmountAsync();
int fromTask = await amountTask.GetValueOrDefaultAsync(0);
```

</details>

<details>
<summary><strong>SelectMany</strong></summary>

LINQ-friendly alias composition for `Bind` + `Map`.
Supports query syntax projections while preserving failure short-circuit behavior.

```csharp
var output =
    from user in Result.Ok(currentUser)
    from account in GetAccount(user.Id)
    select new UserAccountDto(user, account);

var asyncOutput = await GetUserAsync()
    .SelectManyAsync(GetAccountAsync, (user, account) => new UserAccountDto(user, account));
```

</details>

## Example

```csharp
public sealed class ExampleUsage
{
    public string ProcessPayment(int customerId, decimal amount)
    {
        var paymentGateway = new PaymentGateway();
        var database = new Database();

        return GetById(customerId)
            .Tap(customer => customer.AddBalance(amount))
            .Ensure(() => amount > 0, "Amount must be positive")
            .Check(customer => customer.IsActive ? Result.Ok() : Result.Fail("Inactive customer"))
            .Bind(customer => paymentGateway.Charge(customer, amount))
            .Bind(customer => database.Save(customer))
            .Map(customer => customer.Id)
            .Finally(result => result.IsSuccess ? "OK" : result.Errors[0].Message);
    }

    private static Result<Customer> GetById(int id)
        => id > 0 ? Result.Ok(new Customer(id)) : Result.Fail<Customer>("Customer not found: " + id);

    private sealed class Customer
    {
        public Customer(int id) => Id = id;
        public int Id { get; }
        public bool IsActive => true;
        public void AddBalance(decimal amount) { }
    }

    private sealed class PaymentGateway
    {
        public Result<Customer> Charge(Customer customer, decimal amount)
            => Result.Ok(customer);
    }

    private sealed class Database
    {
        public Result<Customer> Save(Customer customer)
            => Result.Ok(customer);
    }
}
```
