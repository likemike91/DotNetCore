using Newtonsoft.Json;
using System.Text;

namespace DotNetCore.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] ToBytes(this object obj)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
        }
    }
}
