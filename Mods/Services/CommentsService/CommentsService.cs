using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ModStoreApi.Models;
using ZstdSharp.Unsafe;

namespace ModStoreApi.Services;

public class CommentsService
{
  private readonly IMongoCollection<Comment> _commentsCollection;

  public CommentsService(
    IOptions<CommentStoreDatabaseSettings> commentStoreDatabaseSetting
  )
  {
    var mongoClient = new MongoClient(commentStoreDatabaseSetting.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(commentStoreDatabaseSetting.Value.DatabaseName);

    _commentsCollection = mongoDatabase.GetCollection<Comment>(commentStoreDatabaseSetting.Value.ModsCollectionName);
  }

  public async Task<List<Comment>> GetAsync() => await _commentsCollection.Find(_ => true).ToListAsync();

  public async Task<List<Comment>> GetAsync(string id) => await _commentsCollection.Find(x => x.Id == id).ToListAsync();
  public async Task<List<Comment>> GetByPostAsync(string id) => await _commentsCollection.Find(x => x.PostId == id).ToListAsync();

  public async Task CreateAsync(Comment newCommentDTO)
  {
    var newComment = new Comment(newCommentDTO);
    await _commentsCollection.InsertOneAsync(newComment);
  }
}
