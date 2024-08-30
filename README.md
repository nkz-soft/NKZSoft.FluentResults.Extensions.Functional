# NKZSoft.FluentResults.Functional.Extensions

![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/nkz-soft/NKZSoft.FluentResults.Extensions.Functional?style=flat-square)
![license](https://img.shields.io/github/license/nkz-soft/NKZSoft.FluentResults.Extensions.Functional?style=flat-square)
![GitHub Workflow Status (with branch)](https://img.shields.io/github/actions/workflow/status/nkz-soft/NKZSoft.FluentResults.Extensions.Functional/build.yaml)

It is a library that extends the popular [FluentResults](https://github.com/altmann/FluentResults) library and helps you write code in a more functional way.
The project was inspired by [Functional Extensions for C#](https://github.com/vkhorikov/CSharpFunctionalExtensions).

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
public async Task<Result<int>> OnSuccess(int x)
...
Result.Ok(1).BindAsync(OnSuccess);
```
