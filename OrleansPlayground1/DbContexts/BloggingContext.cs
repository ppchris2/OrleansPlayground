using Microsoft.EntityFrameworkCore;
using OrleansPlayground.Abstractions;

namespace OrleansPlayground1.DbContexts;

public class BloggingContext : DbContext
{
    public static string ConnectionString = "Host=10.10.48.41:5432;Database=aspnet;Username=chris;Password=password";
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(ConnectionString);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property(f => f.BlogId)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Post>()
            .Property(f => f.PostId)
            .ValueGeneratedOnAdd();
    }
}