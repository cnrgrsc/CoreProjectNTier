using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServiceExtensions
{
    public static class RepManServiceExtension
    {
        public static IServiceCollection AddRepAndManServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

          



            return services;

        }
    }
}
