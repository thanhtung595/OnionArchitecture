using Lib_Data;
using Lib_Data.Abstract;
using Lib_Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Infratruture.Configuration
{
    public static class ConfigurationService
    {
        public static void RegisterContextDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DbContext_MSSQL>(options => 
            options.UseSqlServer(configuration.GetConnectionString("OnionArchitecture"),
            options => options.MigrationsAssembly(typeof(DbContext_MSSQL).Assembly.FullName)));
        }

        public static void RegisterDI(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            service.AddScoped<IDapperHelper,DapperHelper>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IProductService, ProductService>();
        }
    }
}
