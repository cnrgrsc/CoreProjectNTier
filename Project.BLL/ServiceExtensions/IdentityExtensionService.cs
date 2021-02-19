using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.ServiceExtensions
{
    //Identity kullanıyorsanız, (hazır Identity(User,Role,Authorize) sınıflarının , sifremi unuttum işlerinin login register bütün işlemlerinin hazır oldugu kütüphane) 
    public static class IdentityExtensionService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireUppercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();

            return services;
        }
    }
}
