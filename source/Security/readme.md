# DotNetCore.Security

The package provides interfaces and classes for **security**.

## Criptography

### ICriptography

```cs
public interface ICriptography
{
    string Decrypt(string value);

    string Encrypt(string value);
}
```

### Criptography

```cs
public class Criptography : ICriptography
{
    public Criptography(string key) { }

    public string Decrypt(string value) { }

    public string Encrypt(string value) { }
}
```

## Hash

### IHash

```cs
public interface IHash
{
    string Create(string value);

    byte[] Create(byte[] value);
}
```

### Hash

```cs
public class Hash : IHash
{
    public string Create(string value) { }

    public byte[] Create(byte[] value) { }
}
```

## JsonWebToken

### IJsonWebToken

```cs
public interface IJsonWebToken
{
    Dictionary<string, object> Decode(string token);

    string Encode(string sub, string[] roles);
}
```

### JsonWebToken

```cs
public class JsonWebToken : IJsonWebToken
{
    public JsonWebToken(IJsonWebTokenSettings jsonWebTokenSettings) { }

    public Dictionary<string, object> Decode(string token) { }

    public string Encode(string sub, string[] roles) { }
}
```

### JsonWebTokenExtensions

```cs
public static class JsonWebTokenExtensions
{
    public static void AddJti(this ICollection<Claim> claims) { }

    public static void AddRoles(this ICollection<Claim> claims, string[] roles) { }

    public static void AddSub(this ICollection<Claim> claims, string sub) { }
}
```

### IJsonWebTokenSettings

```cs
public interface IJsonWebTokenSettings
{
    string Audience { get; }

    TimeSpan Expires { get; }

    string Issuer { get; }

    string Key { get; }
}
```

### JsonWebTokenSettings

```cs
public class JsonWebTokenSettings : IJsonWebTokenSettings
{
    public JsonWebTokenSettings(string key, TimeSpan expires) { }

    public JsonWebTokenSettings(string key, TimeSpan expires, string audience, string issuer) : this(key, expires) { }

    public string Audience { get; }

    public TimeSpan Expires { get; }

    public string Issuer { get; }

    public string Key { get; }
}
```
