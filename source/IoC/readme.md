# DotNetCore.IoC

The package provides **static classes** with **extensions methods** for **inversion of control**.

## IApplicationBuilderExtensions

```cs
public static class IApplicationBuilderExtensions
{
    public static void UseSpaAngularServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string npmScript) { }

    public static void UseSpaProxyServer(this IApplicationBuilder application, IHostingEnvironment environment, string sourcePath, string baseUri) { }
}
```

## IServiceCollectionExtensions

```cs
public static class IServiceCollectionExtensions
{
    public static void AddClassesMatchingInterfacesFrom(this IServiceCollection services, params Assembly[] assemblies) { }

    public static void AddCriptography(this IServiceCollection services, string key) { }

    public static void AddDbContextEnsureCreatedMigrate<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext { }

    public static void AddDbContextInMemoryDatabase<T>(this IServiceCollection services) where T : DbContext { }

    public static void AddHash(this IServiceCollection services) { }

    public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires) { }

    public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires, string audience, string issuer) { }

    public static void AddJsonWebToken(this IServiceCollection services, JsonWebTokenSettings jsonWebTokenSettings) { }

    public static void AddLogger(this IServiceCollection services, IConfiguration configuration) { }

    public static void AddSpaStaticFiles(this IServiceCollection services, string rootPath) { }

    public static T GetService<T>(this IServiceCollection services) { }
}
```
