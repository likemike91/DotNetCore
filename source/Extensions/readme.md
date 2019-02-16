# DotNetCore.Extensions

The package provides **static classes** with **extensions methods**.

## ByteExtensions

```cs
public static class ByteExtensions
{
    public static byte[] Compress(this byte[] bytes) { }

    public static byte[] Decompress(this byte[] bytes) { }

    public static T ToObject<T>(this byte[] bytes) { }
}
```

## ClaimsPrincipalExtensions

```cs
public static class ClaimsPrincipalExtensions
{
    public static Claim Claim(this ClaimsPrincipal claimsPrincipal, string claimType) { }

    public static string ClaimNameIdentifier(this ClaimsPrincipal claimsPrincipal) { }

    public static long Id(this ClaimsPrincipal claimsPrincipal) { }
}
```

## DateTimeExtensions

```cs
public static class DateTimeExtensions
{
    public static DateTime NextDateTime(this DateTime dateTime, DayOfWeek[] days, TimeSpan[] times) { }

    public static DateTime NextDateTime(this DateTime dateTime, params DayOfWeek[] days) { }

    public static DateTime SetTime(this DateTime dateTime, int hours, int minutes, int seconds) { }
}
```

## EnumExtensions

```cs
public static class EnumExtensions
{
    public static string GetDescription(this Enum value) { }
}
```

## ObjectExtensions

```cs
public static class ObjectExtensions
{
    public static byte[] ToBytes(this object obj) { }
}
```

## PropertyInfoExtensions

```cs
public static class PropertyInfoExtensions
{
    public static IDictionary ToDictionary(this IEnumerable<PropertyInfo> properties) { }
}
```

## QueryableExtensions

```cs
public static class QueryableExtensions
{
    public static IQueryable<T> Order<T>(this IQueryable<T> queryable, string property, bool isAscending) { }

    public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int index, short size) { }
}
```

## StringExtensions

```cs
public static class StringExtensions
{
    public static string CamelCase(this string value) { }

    public static string RemoveSpecialCharacters(this string value) { }
}
```

## TimeSpanExtensions

```cs
public static class TimeSpanExtensions
{
    public static string Format(this TimeSpan time) { }

    public static TimeSpan NextTime(this TimeSpan time, params TimeSpan[] times) { }
}
```

## TypeExtensions

```cs
public static class TypeExtensions
{
    public static IDictionary ToDictionary(this Type type) { }
}
```
