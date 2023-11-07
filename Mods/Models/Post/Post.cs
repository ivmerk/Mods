using System.ComponentModel.DataAnnotations.Schema;
namespace ModStoreApi.Models;

[Table("posts")]
public class Post
{
  [Column("postid")]
  public int? Id { get; set; }

  [Column("slug")]
  public string Slug { get; set; } = string.Empty;

  [Column("title")]
  public string Title { get; set; } = string.Empty;

  [Column("description")]
  public string Description { get; set; } = string.Empty;

  [Column("textbody")]
  public string TextBody { get; set; } = string.Empty;

  [Column("metatagtitle")]
  public string MetaTagTitle { get; set; } = string.Empty;

  [Column("metatagdescription")]
  public string MetaTagDescription { get; set; } = string.Empty;

  [Column("metatagkeywords")]
  public string[] MetaTagKeywords { get; set; } = Array.Empty<string>();

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

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
    TextBody = post.TextBody;
    MetaTagTitle = post.MetaTagTitle;
    MetaTagDescription = post.MetaTagDescription;
    MetaTagKeywords = post.MetaTagKeywords;
    CreatedAt = DateTime.Now.ToUniversalTime();
    UpdatedAt = DateTime.Now.ToUniversalTime();
  }
}
