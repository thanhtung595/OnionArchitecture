using Lib_Data.Abstract;
using Lib_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Service
{
    public class CategoryService : ICategoryService
    {
        IRepository<Category> _categoryRepository;
        IDapperHelper _apperHelper;
        public CategoryService(IRepository<Category> categoryRepository, IDapperHelper apperHelper)
        {
            _categoryRepository = categoryRepository;
            _apperHelper = apperHelper;

        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<IEnumerable<Category>> GetCategoriesSQLAsync()
        {
            string sql = $"Select * FROM Category";
            return await _apperHelper.ExcuteSqlReturnList<Category>(sql);
        }
    }
}
