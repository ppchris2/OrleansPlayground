using Microsoft.EntityFrameworkCore;
using OrleansPlayground1;
using OrleansPlayground1.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BloggingContext>(options =>
    options.UseNpgsql(BloggingContext.ConnectionString));

builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseDashboard();
    siloBuilder.UseLocalhostClustering();
    siloBuilder.AddMemoryGrainStorage("urls");
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<BloggingContext>();
    
    dbContext.Database.Migrate();
}

app.Maps();

app.Run();