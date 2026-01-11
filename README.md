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
