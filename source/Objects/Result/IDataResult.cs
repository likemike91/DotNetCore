namespace DotNetCore.Objects
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
