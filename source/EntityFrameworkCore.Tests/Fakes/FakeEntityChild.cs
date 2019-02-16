namespace DotNetCore.EntityFrameworkCore.Tests
{
    public class FakeEntityChild
    {
        public long Id { get; set; }

        public long FakeEntityId { get; set; }

        public virtual FakeEntity FakeEntity { get; set; }
    }
}
