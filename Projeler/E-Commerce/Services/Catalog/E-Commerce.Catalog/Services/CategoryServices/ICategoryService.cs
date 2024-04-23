using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Catalog.Entities;

namespace E_Commerce.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Task<Category> GetById(string id);
        Task<bool> Create(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(string id);
    }
}