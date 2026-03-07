# NKZSoft.FluentResults.Functional.Extensions

![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/nkz-soft/NKZSoft.FluentResults.Extensions.Functional?style=flat-square)
![license](https://img.shields.io/github/license/nkz-soft/NKZSoft.FluentResults.Extensions.Functional?style=flat-square)
![GitHub Workflow Status (with branch)](https://img.shields.io/github/actions/workflow/status/nkz-soft/NKZSoft.FluentResults.Extensions.Functional/build.yaml)

It is a library that extends the popular [FluentResults](https://github.com/altmann/FluentResults) library and helps you write code in a more functional way.
The project was inspired by [Functional Extensions for C#](https://github.com/vkhorikov/CSharpFunctionalExtensions).

### ⭐ Give a star

If you're using this repository for your learning, samples or your project, please give a star. Thanks :+1:

## Installation

Available on [NuGet](https://www.nuget.org/packages/NKZSoft.FluentResults.Extensions.Functional/)

```bash
dotnet add package NKZSoft.FluentResults.Extensions.Functional
```

## Features
All methods have asynchronous overloads and ValueTask support.

### Bind

It executes the function only if the Result is successful (i.e., not failed). If the Result is failed, it returns the original failed Result. 
If the Result is successful, it executes the function and returns the resulting Result.

```csharp
public async Task<Result<int>> OnSuccessAsync(int x)
...
await Result.Ok(1).BindAsync(OnSuccessAsync);
```

### Finally

Executes a function after a Result, regardless of its success or failure.

```csharp
public async Task<int> OnBothAsync(Result result)
...
await Result.Ok().FinallyAsync(OnBothAsync);
```
### Tap

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

### Match

Matches a Result to either a success or failure action.

```csharp
public async Task OnSuccessAsync()
...
public async Task OnFailureAsync(IReadOnlyList<IError> errors)
...

await Result.Ok().MatchAsync(OnActionAsync, OnFailureAsync);
```

### Ensure

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

### EnsureNot

`EnsureNot` provides CSharpFunctionalExtensions-style inverted predicate checks for `Result<TValue>`.
It fails when the predicate evaluates to `true`.

```csharp
var output = Result.Ok(15)
    .EnsureNot(x => x > 10, "Value should be less than or equal to 10");

Task<Result<int>> maybeAmountTask = GetAmountAsync();
Result<int> ensuredFromTask = await maybeAmountTask
    .EnsureNotAsync(x => x > 10, "Value should be less than or equal to 10");
```

### Required

Requires a successful result value to be non-null.
If the source result is failed, errors are preserved.

```csharp
Result<string?> maybeName = Result.Ok<string?>(null);
Result<string> requiredName = maybeName.Required("Name is required");

Task<Result<string?>> maybeNameTask = GetNameAsync();
Result<string> requiredFromTask = await maybeNameTask.RequiredAsync("Name is required");
```

### EnsureNotNull

`EnsureNotNull` provides CSharpFunctionalExtensions-style naming for non-null validation and follows the same behavior as `Required`.

```csharp
Result<string?> maybeEmail = Result.Ok<string?>(null);
Result<string> ensuredEmail = maybeEmail.EnsureNotNull("Email is required");

Task<Result<string?>> maybeEmailTask = GetEmailAsync();
Result<string> ensuredFromTask = await maybeEmailTask.EnsureNotNullAsync("Email is required");
```

### Try

Executes code and converts thrown exceptions to failed `Result` values.

```csharp
var saveResult = ResultExtensions.Try(() => Save(customer));

var loadResult = await ResultExtensions.TryAsync(
    async () => await repository.LoadAsync(id),
    ex => $"Load failed: {ex.Message}");
```

### Of

Creates successful results from values and value-producing delegates.
Unlike `Try`, exceptions are not converted to failure results and are propagated to the caller.

```csharp
var fromValue = ResultExtensions.Of(42);

var fromFunc = ResultExtensions.Of(() => ComputeValue());

var fromTask = await ResultExtensions.OfAsync(repository.GetByIdAsync(id));

var fromValueTask = await ResultExtensions.OfAsync(GetValueValueTaskAsync);
```

### Check

Executes a function only if the Result is successful, acting as a validation step in a chain.
If the function returns failure, the failure is returned; otherwise it returns the original result.

```csharp
public Task<Result> EnsureUniqueEmailAsync(string email)
...
var output = await GetUserAsync()
    .CheckAsync(user => EnsureUniqueEmailAsync(user.Email))
    .BindAsync(SaveAsync);
```

### Map

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

### Select

LINQ-friendly alias for `Map`.
If the Result is failed, returns a failed Result with the same errors.

```csharp
var output = Result.Ok(1).Select(v => v + 1);

public Task<Result<int>> GetNumberAsync()
...
var output2 = await GetNumberAsync().SelectAsync(v => v + 1);
```

### SelectMany

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
