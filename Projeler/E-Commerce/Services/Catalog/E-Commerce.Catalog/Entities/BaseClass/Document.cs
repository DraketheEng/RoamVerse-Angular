using E_Commerce.Catalog.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Catalog.Entities.BaseClass;

public abstract class Document : IDocument
{
    [BsonElement("id")]
    [BsonRepresentation(BsonType.String)]
    public string? Id { get; set; }

    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}