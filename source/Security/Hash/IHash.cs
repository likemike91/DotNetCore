namespace DotNetCore.Security
{
    public interface IHash
    {
        string Create(string value);

        byte[] Create(byte[] value);
    }
}
