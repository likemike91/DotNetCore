namespace DotNetCore.EntityFrameworkCore.Tests
{
    public sealed class FakeRepository : EntityFrameworkCoreRepository<FakeEntity>, IFakeRepository
    {
        public FakeRepository(FakeContext context) : base(context)
        {
        }
    }
}
