namespace ModStoreApi.Models;

public class CreatePostDTO
{
  public string VendorCode { get; set; } = null!;

  public string Title { get; set; } = null!;

  public string Description { get; set; } = null!;

  public string TextBody { get; set; } = null!;
}
