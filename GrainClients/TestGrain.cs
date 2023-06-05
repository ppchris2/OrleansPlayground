using Microsoft.EntityFrameworkCore;
using Orleans.Runtime;
using OrleansPlayground.Abstractions;
using OrleansPlayground1.DbContexts;

namespace GrainClients;

public class TestGrain : Grain, ITestGrain
{
    private readonly BloggingContext _bloggingContext;
    
    public TestGrain(BloggingContext bloggingContext)
    {
        _bloggingContext = bloggingContext;
    }

    public async Task<Blog> AddBlogs(string url)
    {
        var blog = new Blog()
        {
            Url = url
        };
        _bloggingContext.Blogs.Add(blog);
        
        await _bloggingContext.SaveChangesAsync();
        
        await Task.Delay(1000);
        return blog;
    }
    
    public async Task<Post> AddPosts(string title, string content, int blogId)
    {
        var post = new Post()
        {
            Title = title,
            Content = content,
            BlogId = blogId
        };
        _bloggingContext.Posts.Add(post);

        await _bloggingContext.SaveChangesAsync();
        await Task.Delay(1000);
        
        return post;
    }

    public Task<Post[]> GetPosts(int? postId)
    {
        return postId.HasValue
            ? _bloggingContext.Posts.Where(x => x.PostId == postId.Value).ToArrayAsync()
            : _bloggingContext.Posts.ToArrayAsync();    
    }

    public Task<Post> GetBlogs()
    {
        throw new NotImplementedException();
    }
}
