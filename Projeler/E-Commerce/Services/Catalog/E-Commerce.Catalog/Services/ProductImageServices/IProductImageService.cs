using E_Commerce.Catalog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        List<ProductImages> GetAll();
        Task<ProductImages> GetById(string id);
        Task<bool> Create(ProductImages productImages);
        Task<bool> Delete(string id);
        Task<bool> Update(ProductImages productImages);
    }
}