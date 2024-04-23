using System.Linq.Expressions;
using E_Commerce.Catalog.Entities.BaseClass;
using E_Commerce.Catalog.MongoDB.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.MongoDB.Repository;

public class MongoDbServices<TDocument> : IMongoDbServices<TDocument> where TDocument : IDocument
{
    protected readonly IMongoCollection<TDocument> Collection;
    
    public MongoDbServices(IMongoDbSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        string collectionName = GetCollectionName(typeof(TDocument));
        Collection = database.GetCollection<TDocument>(collectionName);
    }

    private string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()!)?.CollectionName;
    }
    
  
    public virtual IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Collection.Find(filterExpression).ToEnumerable();
    }

    public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Collection.Find(filterExpression).FirstOrDefault();
    }

    public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Task.Run(() => Collection.Find(filterExpression).FirstOrDefaultAsync());
    }

    public virtual TDocument FindById(string id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        return Collection.Find(filter).SingleOrDefault();
    }
    
    public virtual Task<TDocument> FindByIdAsync(string id)
    {
        return Task.Run(() =>
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            return Collection.Find(filter).SingleOrDefaultAsync();
        });
    }
    
    public virtual void InsertOne(TDocument document)
    {
        if (string.IsNullOrEmpty(document.Id))
        {
            document.Id = Guid.NewGuid().ToString();
        }

        document.CreateDate = DateTime.Now;

        Collection.InsertOne(document);
    }

    public virtual Task InsertOneAsync(TDocument document)
    {
        if (string.IsNullOrEmpty(document.Id))
        {
            document.Id = Guid.NewGuid().ToString();
        }

        document.CreateDate = DateTime.Now;

        return Task.Run(() => Collection.InsertOneAsync(document));
    }
    
    
        public void InsertMany(ICollection<TDocument> documents)
        {
            Collection.InsertMany(documents);
        }


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await Collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(TDocument document)
        {
            document.UpdateDate = DateTime.Now;

            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            Collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            document.UpdateDate = DateTime.Now;

            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await Collection.FindOneAndReplaceAsync(filter, document);
        }

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            Collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => Collection.FindOneAndDeleteAsync(filterExpression));
        }

        public void DeleteById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            Collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
                Collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            Collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => Collection.DeleteManyAsync(filterExpression));
        }
}