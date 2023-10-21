using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModStoreApi.Models;

public class Post
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  public string Slug { get; set; } = null!;

  public string Title { get; set; } = null!;

  public string Description { get; set; } = null!;

  [BsonElement("MetaTag")]
  public List<MetaTag> MetaTags { get; set; } = new List<MetaTag>();
  public string TextBody { get; set; } = null!;
  [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
  public DateTime? CreationDate { get; set; }
  [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
  public DateTime? UpdateDate { get; set; }

  public Post()
  {

  }
  public Post(Post post)
  {
    FillEntity(post);
  }

  public void FillEntity(Post post)
  {
    Slug = post.Slug;
    Title = post.Title;
    Description = post.Description;
    MetaTags = post.MetaTags;
    TextBody = post.TextBody;
    CreationDate = DateTime.Now.Date;
    UpdateDate = DateTime.Now.Date;
  }
}


public class MetaTag
{
  public string? Title { get; set; }

  public string? Description { get; set; }
  public string[]? Keywords { get; set; }
}