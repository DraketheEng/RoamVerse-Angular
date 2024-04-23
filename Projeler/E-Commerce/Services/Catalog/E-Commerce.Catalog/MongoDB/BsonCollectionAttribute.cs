namespace E_Commerce.Catalog.MongoDB;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BsonCollectionAttribute : Attribute
{
    public string? CollectionName { get; }

    public BsonCollectionAttribute(string? collectionName)
    {
        CollectionName = collectionName;
    }
}