using Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Tags
{
    internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable(nameof(Tag));
            builder.HasKey(tag => tag.Id);
            builder.Property(tag => tag.Value).IsRequired().HasMaxLength(30);
            builder.HasIndex(tag => tag.Value).IsUnique();
        }
    }
}
