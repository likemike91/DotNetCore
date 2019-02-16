using System;

namespace DotNetCore.Security
{
    public interface IJsonWebTokenSettings
    {
        string Audience { get; }

        TimeSpan Expires { get; }

        string Issuer { get; }

        string Key { get; }
    }
}
