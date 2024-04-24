using Lib_Data.Abstract;
using Lib_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Service
{
    public class ProductService : IProductService
    {
        IRepository<Product> _productyRepository;
        IDapperHelper _apperHelper;
        public ProductService(IRepository<Product> productyRepository, IDapperHelper apperHelper)
        {
            _productyRepository = productyRepository;
            _apperHelper = apperHelper;

        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _productyRepository.GetAll();
        }

        // ProductService
        public async Task<IEnumerable<Product>> GetProductsWithCategoriesAsync()
        {
            var products = await _productyRepository.GetAllIncluding(p => p.Id == 1, p => p.Category); // Lấy danh sách sản phẩm
            
            return products;
        }
    }
}
