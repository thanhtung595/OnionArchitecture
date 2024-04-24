using Lib_Domain.Entities;

namespace Lib_Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesSQLAsync();
    }
}