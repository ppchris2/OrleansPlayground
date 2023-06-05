using Orleans;

namespace OrleansPlayground.Abstractions;

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}

public interface ITestGrain : IGrainWithStringKey
{
    Task<Blog> AddBlogs(string url);
    Task<Post> AddPosts(string title, string content, int blogId);
    Task<Post[]> GetPosts(int? postId);
}