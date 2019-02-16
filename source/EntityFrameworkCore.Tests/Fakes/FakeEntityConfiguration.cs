using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore.EntityFrameworkCore.Tests
{
    public sealed class FakeEntityConfiguration : IEntityTypeConfiguration<FakeEntity>
    {
        public void Configure(EntityTypeBuilder<FakeEntity> builder)
        {
            builder.ToTable(nameof(FakeEntity));
            builder.HasKey(x => x.FakeEntityId);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.FakeEntityChild).WithOne(x => x.FakeEntity).HasForeignKey(x => x.FakeEntityId);
        }
    }
}
