using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ModStoreApi.Models;

namespace ModStoreApi.Services;

public class PostsService
{

  private readonly IMongoCollection<Post> _postsCollection;

  public PostsService(
    IOptions<PostStoreDatabaseSettings> postStoreDatabaseSetting
  )
  {
    var mongoClient = new MongoClient(postStoreDatabaseSetting.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(postStoreDatabaseSetting.Value.DatabaseName);

    _postsCollection = mongoDatabase.GetCollection<Post>(postStoreDatabaseSetting.Value.ModsCollectionName);
  }
  public async Task<List<Post>> GetAsync() => await _postsCollection.Find(_ => true).ToListAsync();

  public async Task<Post?> GetAsync(string id) =>
      await _postsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
  public async Task CreateAsync(Post newPostDTO)
  {
    var newPost = new Post(newPostDTO);
    await _postsCollection.InsertOneAsync(newPost);
  }

  public async Task UpdateAsync(string id, UpdatePostDTO updatedPost)
  {
    var post = await GetAsync(id) ?? throw new ArgumentException($"Нет поста с таким  Id");
    post.Title = updatedPost.Title ?? post.Title;
    post.Description = updatedPost.Description ?? post.Description;
    post.TextBody = updatedPost.TextBody ?? post.TextBody;
    post.MetaTags = updatedPost.MetaTags ?? post.MetaTags;
    post.UpdateDate = DateTime.Now.Date;
    await _postsCollection.ReplaceOneAsync(x => x.Id == id, post);
  }

}
