using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using ModStoreApi.Models;
using ModStoreApi.Repository;
using ModStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.Configure<ModStoreDatabaseSettings>(builder.Configuration.GetSection("ModStoreDatabase"));
// builder.Services.Configure<PostStoreDatabaseSettings>(builder.Configuration.GetSection("PostStoreDatabase"));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.Configure<CommentStoreDatabaseSettings>(builder.Configuration.GetSection("CommentStoreDatabase"));

builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddScoped<ModsService>();
builder.Services.AddScoped<CommentsService>();
builder.Services.AddScoped<PostsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

