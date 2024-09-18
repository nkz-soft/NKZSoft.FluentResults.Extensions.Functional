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
public async Task OnFailureAsync(IList<IError> errors)
...

await Result.Ok().MatchAsync(OnActionAsync, OnFailureAsync);
```

### Ensure

Ensures that a condition is met for a successful Result.
If the condition is not met, returns a failed Result with the specified error message.

```csharp
var outputResult = await result.EnsureAsync(() => true, FailErrorMessage);
```
