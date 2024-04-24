using Lib_Domain.Entities;

namespace Lib_Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<IEnumerable<Product>> GetProductsWithCategoriesAsync();
    }
}