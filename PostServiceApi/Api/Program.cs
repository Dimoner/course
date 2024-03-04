using Application.Comments.Services;
using Application.PostLikes.Services;
using Application.Posts.Services;
using Application.Tags.Services;
using Domain.Comments;
using Domain.PostLikes;
using Domain.Posts;
using Domain.Tags;
using Infrastructure.Comments;
using Infrastructure.PostLikes;
using Infrastructure.Posts;
using Infrastructure.Tags;
using Microsoft.AspNetCore.Mvc.Formatters;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(options =>
        {
            options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            options.ReturnHttpNotAcceptable = true;
            options.RespectBrowserAcceptHeader = true;
        }).AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Adding repositories
        builder.Services.AddScoped<ICommentRepository, CommentsRepository>();
        builder.Services.AddScoped<IPostLikeRepository, PostLikeRepository>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();

        // Adding services
        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<IPostLikeService, PostLikeService>();
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<ITagService, TagService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
