using E_Commerce.Catalog.Entities.BaseClass;
using E_Commerce.Catalog.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Catalog.Entities;

[BsonCollection("ProductDetail")]

public class ProductDetail : Document
{
    public string ProductDescription { get; set; }
    
    public string ProductInfo { get; set; }
    
    public string ProductId { get; set; }
    
    [BsonIgnore]
    public Product Product { get; set; }
}