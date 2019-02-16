using System.Collections.Generic;

namespace DotNetCore.EntityFrameworkCore.Tests
{
    public class FakeEntity
    {
        public long FakeEntityId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FakeEntityChild> FakeEntityChild { get; set; } = new HashSet<FakeEntityChild>();
    }
}
