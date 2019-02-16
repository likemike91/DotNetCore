# DotNetCore.AspNetCore

The package provides action results, attributes, extensions, middlewares and providers for **ASP.NET Core**.

## Action Results

### Result

```cs
public class Result : IActionResult
{
    public Result(IResult result) { }

    public async Task ExecuteResultAsync(ActionContext context) { }
}
```

### DataResult

```cs
public class DataResult : IActionResult
{
    public DataResult(IDataResult<object> result) { }

    public async Task ExecuteResultAsync(ActionContext context) { }
}
```

## Attributes

### AuthorizeEnumAttribute

```cs
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class AuthorizeEnumAttribute : AuthorizeAttribute
{
    public AuthorizeEnumAttribute(params object[] roles) { }
}
```

### RouteControllerAttribute

```cs
[AttributeUsage(AttributeTargets.Class)]
public sealed class RouteControllerAttribute : RouteAttribute
{
    public RouteControllerAttribute() : base("[controller]") { }
}
```

## Extensions

### ApplicationBuilderExtensions

```cs
public static class ApplicationBuilderExtensions
{
    public static void UseCorsDefault(this IApplicationBuilder application) { }

    public static void UseExceptionDefault(this IApplicationBuilder application, IHostingEnvironment environment) { }

    public static void UseHstsDefault(this IApplicationBuilder application, IHostingEnvironment environment) { }

    public static void UseSwaggerDefault(this IApplicationBuilder application) { }
}
```

### HttpRequestExtensions

```cs
public static class HttpRequestExtensions
{
    public static IList<FileBinary> Files(this HttpRequest request) { }
}
```

### IHostingEnvironmentExtensions

```cs
public static class IHostingEnvironmentExtensions
{
    public static IConfiguration Configuration(this IHostingEnvironment environment) { }
}
```

### IServiceCollectionExtensions

```cs
public static class IServiceCollectionExtensions
{
    public static void AddAuthenticationDefault(this IServiceCollection services) { }

    public static void AddMvcDefault(this IServiceCollection services) { }

    public static void AddSwaggerDefault(this IServiceCollection services) { }
}
```

## Middlewares

### ExceptionMiddleware

It centralizes exception handling and saves logs.
