# DotNetCore.Validation

The package provides classes for **validation**.

## RegularExpressions

```cs
public static class RegularExpressions
{
    public const string Date;

    public const string Decimal;

    public const string Email;

    public const string Hex;

    public const string Integer;

    public const string Login;

    public const string Password;

    public const string Tag;

    public const string Time;

    public const string Url;
}
```

## Validator\<T\>

It provides a method to validate and throw exception of type **ApplicationException**, with a generic error message, or a list of error messages from rules of **FluentValidation** package.

```cs
public abstract class Validator<T> : AbstractValidator<T>
{
    protected Validator() { }

    protected Validator(string errorMessage) { }

    private string ErrorMessage { get; set; }

    public IResult Valid(T instance) { }
}
```
