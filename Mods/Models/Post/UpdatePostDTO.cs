namespace ModStoreApi.Models;
public class UpdatePostDTO
{
  public string? Id { get; set; } = null!;

  public string? Title { get; set; }

  public string? Description { get; set; }
  // public List<MetaTag>? MetaTags { get; set; }

  public string? TextBody { get; set; }
}

