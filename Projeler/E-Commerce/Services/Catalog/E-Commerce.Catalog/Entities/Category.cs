using E_Commerce.Catalog.Entities.BaseClass;
using E_Commerce.Catalog.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Catalog.Entities;

[BsonCollection("Category")]
public class Category : Document
{
    public string CategoryName { get; set; }
}