using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModStoreApi.Models;

public class Mod
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonElement("Name")]
  public string ModName { get; set; } = null!;

  public ushort Level { get; set; }

  public string Stat { get; set; } = null!;

  public string[] Tags { get; set; } = null!;

}