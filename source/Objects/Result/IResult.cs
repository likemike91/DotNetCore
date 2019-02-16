namespace DotNetCore.Objects
{
    public interface IResult
    {
        string Message { get; }

        bool Success { get; }
    }
}
