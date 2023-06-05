using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrleansPlayground.Abstractions;
using OrleansPlayground1.DbContexts;

namespace OrleansPlayground1;

public static class ProgramExtensions
{
    public static void Maps(this WebApplication app)
    {
        app.MapGet("/",  ([FromQuery]int? postId, ITestGrain testGrain) => 
            testGrain.GetPosts(postId));

        app.MapPost("/addBlog", ([FromQuery]string url, ITestGrain testGrain) => 
            testGrain.AddBlogs(url));

        app.MapPost("/addPost", ([FromQuery]string title, [FromQuery]string content, [FromQuery]int blogId, ITestGrain testGrain) => 
            testGrain.AddPosts(title, content, blogId));
    }
}