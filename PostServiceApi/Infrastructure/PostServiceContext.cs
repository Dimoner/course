using Domain.Comments;
using Domain.PostLikes;
using Domain.Posts;
using Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public sealed class PostServiceContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<PostLike> PostLikes { get; set; } = null!;

        public PostServiceContext(DbContextOptions<PostServiceContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostServiceContext).Assembly);
    }
}
