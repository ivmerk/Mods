using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModStoreApi.Models;


public class Comment
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  public string PostId { get; set; } = null!;
  public string UserId { get; set; } = null!;

  public string Text { get; set; } = null!;

  [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
  public DateTime CreationDate { get; set; }

  public Comment()
  {
    // Конструктор без параметров
  }
  public Comment(Comment comment)
  {
    FillEntity(comment);
  }
  public void FillEntity(Comment comment)
  {
    PostId = comment.PostId;
    UserId = comment.UserId;
    Text = comment.Text;
    CreationDate = DateTime.Now.Date;
  }
}
