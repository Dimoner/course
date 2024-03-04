using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Posts
{
    internal sealed class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(nameof(Post));

            builder.HasKey(post => post.Id);
            
            builder.Property(post => post.UserId).IsRequired();
            builder.Property(post => post.Content).IsRequired();
            builder.Property(post => post.LikesCount).IsRequired();
            builder.Property(post => post.CommentsCount).IsRequired();
            builder.Property(post => post.CreatedAt).IsRequired();
            builder.Property(post => post.UpdatedAt);
            builder.Property(post => post.Tags);
        }
    }
}
