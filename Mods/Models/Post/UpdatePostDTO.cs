namespace ModStoreApi.Models;
public class UpdatePostDTO
{
  public string? Title { get; set; }

  public string? Description { get; set; }

  public string? TextBody { get; set; }

  public string? MetaTagTitle { get; set; }


  public string? MetaTagDescription { get; set; }


  public string[]? MetaTagKeywords { get; set; }

}

