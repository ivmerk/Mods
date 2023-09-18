using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ModStoreApi.Models;

namespace ModStoreApi.Services;

public class ModsService
{

  private readonly IMongoCollection<Mod> _modsCollection;

  public ModsService(
    IOptions<ModStoreDatabaseSettings> modStoreDatabaseSetting
  )
  {
    var mongoClient = new MongoClient(modStoreDatabaseSetting.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(modStoreDatabaseSetting.Value.DatabaseName);

    _modsCollection = mongoDatabase.GetCollection<Mod>(modStoreDatabaseSetting.Value.ModsCollectionName);
  }
  public async Task<List<Mod>> GetAsync() => await _modsCollection.Find(_ => true).ToListAsync();

  public async Task<Mod?> GetAsync(string id) =>
      await _modsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

  public async Task CreateAsync(Mod newMod) =>
    await _modsCollection.InsertOneAsync(newMod);

  public async Task UpdateAsync(string id, Mod updateMod) =>
    await _modsCollection.ReplaceOneAsync(x => x.Id == id, updateMod);

  public async Task RemoveAsync(string id) =>
    await _modsCollection.DeleteOneAsync(x => x.Id == id);
}