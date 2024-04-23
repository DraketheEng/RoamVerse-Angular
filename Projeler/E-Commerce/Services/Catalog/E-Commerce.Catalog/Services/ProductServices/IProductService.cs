using E_Commerce.Catalog.Entities;

namespace E_Commerce.Catalog.Services.ProductServices;

public interface IProductService
{
    List<Product> GetAll();
    Task<Product> GetById(string id);
    Task<bool> Create(Product product);
    Task<bool> Delete(string id);
    Task<bool> Update(Product product);
}