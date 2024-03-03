using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.PostLikes;

namespace Infrastructure.PostLikes
{
    internal sealed class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
    {
        public void Configure(EntityTypeBuilder<PostLike> builder)
        {
            builder.ToTable(nameof(PostLike));
            builder.HasKey(postLike => postLike.Id);
            builder.Property(postLike => postLike.PostId).IsRequired();
            builder.Property(postLike => postLike.UserId).IsRequired();
        }
    }
}
