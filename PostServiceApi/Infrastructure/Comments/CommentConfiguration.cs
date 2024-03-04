using Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Comments
{
    internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(nameof(Comment));

            builder.HasKey(comment => comment.Id);

            builder.Property(comment => comment.UserId).IsRequired();
            builder.Property(comment => comment.PostId).IsRequired();
            builder.Property(comment => comment.Content).IsRequired();
            builder.Property(comment => comment.CreatedAt).IsRequired();
            builder.Property(comment => comment.UpdatedAt);

            builder.HasIndex(comment => comment.PostId);
        }
    }
}
