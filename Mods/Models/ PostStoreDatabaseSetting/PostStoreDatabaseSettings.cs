namespace ModStoreApi.Models;

public class PostStoreDatabaseSettings
{
  public string ConnectionString { get; set; } = null!;
  public string DatabaseName { get; set; } = null!;
  public string ModsCollectionName { get; set; } = null!;
}

