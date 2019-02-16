using System.Collections.Generic;

namespace DotNetCore.Security
{
    public interface IJsonWebToken
    {
        Dictionary<string, object> Decode(string token);

        string Encode(string sub, string[] roles);
    }
}
