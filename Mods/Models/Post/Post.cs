using System.ComponentModel.DataAnnotations.Schema;
namespace ModStoreApi.Models;

[Table("posts")]
public class Post
{
  [Column("postid")]
  public int? Id { get; set; }

  [Column("slug")]
  public string Slug { get; set; } = null!;

  [Column("title")]
  public string Title { get; set; } = null!;

  [Column("description")]
  public string Description { get; set; } = null!;

  // public List<MetaTag> MetaTags { get; set; } = new List<MetaTag>();
  [Column("textbody")]
  public string TextBody { get; set; } = null!;
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
    // MetaTags = post.MetaTags;
    TextBody = post.TextBody;
    CreatedAt = DateTime.Now.ToUniversalTime();
    UpdatedAt = DateTime.Now.ToUniversalTime();
  }
}


// public class MetaTag
// {
//   public string? Title { get; set; }

//   public string? Description { get; set; }
//   public string[]? Keywords { get; set; }
// }