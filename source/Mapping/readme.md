# DotNetCore.Mapping

The package provides a **static class** with **extension methods** for **mapping**.

```cs
public static class MapperExtensions
{
    public static TSource Clone<TSource>(this TSource source) { }

    public static TDestination Map<TSource, TDestination>(this TSource source) { }

    public static TDestination Map<TDestination>(this object source) { }

    public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination) { }

    public static IQueryable<TDestination> Project<TSource, TDestination>(this IQueryable<TSource> queryable) { }
}
```
