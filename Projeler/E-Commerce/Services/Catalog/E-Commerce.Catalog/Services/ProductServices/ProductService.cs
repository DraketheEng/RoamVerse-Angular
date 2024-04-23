using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.MongoDB.Repository;

namespace E_Commerce.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoDbServices<Product> _productServices;

    public ProductService(IMongoDbServices<Product> productServices)
    {
        _productServices = productServices;
    }
    
    public List<Product> GetAll()
    {
        var list = _productServices.FilterBy(x => true).ToList();
        return list;
    }

    public async Task<Product> GetById(string id)
    {
        var product = await _productServices.FindByIdAsync(id);
        return product;
    }

    public async Task<bool> Create(Product product)
    {
        await _productServices.InsertOneAsync(product);
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        await _productServices.DeleteOneAsync(x => x.Id == id);
        return true;
    }

    public async Task<bool>  Update(Product product)
    {
        await _productServices.ReplaceOneAsync(product);
        return true;
    }
}