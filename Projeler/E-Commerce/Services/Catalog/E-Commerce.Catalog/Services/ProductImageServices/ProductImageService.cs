using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.MongoDB.Repository;

namespace E_Commerce.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMongoDbServices<ProductImages> _productImageService;

    public ProductImageService(IMongoDbServices<ProductImages> productImageService)
    {
        _productImageService = productImageService;
    }
    
    public List<ProductImages> GetAll()
    {
        var list = _productImageService.FilterBy(x => true).ToList();
        return list;
    }

    public async Task<ProductImages> GetById(string id)
    {
        var productImages = await _productImageService.FindByIdAsync(id);
        return productImages;
    }

    public async Task<bool> Create(ProductImages productImages)
    {
        await _productImageService.InsertOneAsync(productImages);
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        await _productImageService.DeleteOneAsync(x => x.Id == id);
        return true;
    }

    public async Task<bool>  Update(ProductImages productImages)
    {
        await _productImageService.ReplaceOneAsync(productImages);
        return true;
    }
}