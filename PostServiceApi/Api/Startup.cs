using Application.Comments.Mappers;
using Application.Comments.Services;
using Application.PostLikes.Mappers;
using Application.PostLikes.Services;
using Application.Posts.Mappers;
using Application.Posts.Services;
using Application.Tags.Mappers;
using Application.Tags.Services;
using Domain.Comments;
using Domain.PostLikes;
using Domain.Posts;
using Domain.Tags;
using Infrastructure;
using Infrastructure.Comments;
using Infrastructure.PostLikes;
using Infrastructure.Posts;
using Infrastructure.Tags;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            ConfigureControllers(services);
            ConfigureSwagger(services);
            AddMappers(services);
            AddRepositories(services);
            AddServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PostServiceContext>(options => options.UseNpgsql(connection));
        }

        private static void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                options.ReturnHttpNotAcceptable = true;
                options.RespectBrowserAcceptHeader = true;
            }).AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ICommentRepository, CommentsRepository>();
            services.AddScoped<IPostLikeRepository, PostLikeRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostLikeService, PostLikeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
        }

        private static void AddMappers(IServiceCollection services)
        {
            services.AddScoped<ICommentViewModelMapper, CommentViewModelMapper>();
            services.AddScoped<IPostLikeViewModelMapper, PostLikeViewModelMapper>();
            services.AddScoped<ITagViewModelMapper, TagViewModelMapper>();
            services.AddScoped<IPostViewModelMapper, PostViewModelMapper>();
        }
    }
}
