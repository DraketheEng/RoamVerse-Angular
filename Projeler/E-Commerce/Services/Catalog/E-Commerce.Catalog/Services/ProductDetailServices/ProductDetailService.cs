using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.MongoDB.Repository;
using E_Commerce.Catalog.Services.ProductServices;

namespace E_Commerce.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMongoDbServices<ProductDetail> _productDetailServices;

    public ProductDetailService(IMongoDbServices<ProductDetail> productDetailServices)
    {
        _productDetailServices = productDetailServices;
    }
    
    public List<ProductDetail> GetAll()
    {
        var list = _productDetailServices.FilterBy(x => true).ToList();
        return list;
    }

    public async Task<ProductDetail> GetById(string id)
    {
        var productDetail = await _productDetailServices.FindByIdAsync(id);
        return productDetail;
    }

    public async Task<bool> Create(ProductDetail productDetail)
    {
        await _productDetailServices.InsertOneAsync(productDetail);
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        await _productDetailServices.DeleteOneAsync(x => x.Id == id);
        return true;
    }

    public async Task<bool>  Update(ProductDetail productDetail)
    {
        await _productDetailServices.ReplaceOneAsync(productDetail);
        return true;
    }
}