using System.ComponentModel.DataAnnotations.Schema;

namespace ModStoreApi.Models;

[Table("comments")]

public class Comment
{
  [Column("commentid")]
  public int? Id { get; set; }

  [Column("postid")]
  public int PostId { get; set; } = 0;

  [Column("userid")]
  public int UserId { get; set; } = 0;

  [Column("textbody")]
  public string TextBody { get; set; } = string.Empty;

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  public Comment()
  {
  }
  public Comment(Comment comment)
  {
    FillEntity(comment);
  }
  public void FillEntity(Comment comment)
  {
    PostId = comment.PostId;
    UserId = comment.UserId;
    TextBody = comment.TextBody;
    CreatedAt = DateTime.Now.ToUniversalTime();
    UpdatedAt = DateTime.Now.ToUniversalTime();
  }
}
