﻿using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using Autofac.Extensions.DependencyInjection;

using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Project.DAL.DALModel;

namespace Project.BLL.DependencyResolvers
{
    //System.Reflection degil Autofac kütüphanesinin Module isimli sınıfını kullanmalısınız...
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(BaseManager<>)).As(typeof(IManager<>));
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryManager>().As<ICategoryManager>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UserManagerSpecial>().As<IUserManagerSpecial>();
            builder.RegisterType<LoginManager>().As<ILoginManager>();

            IServiceCollection ni = new ServiceCollection();

            ni.AddIdentity<AppUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireUppercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();

            //bu noktada kesinlikle builder, Populate metodu ile Identity eklenmiş olan ServiceCollection nesnesini almak zorundadır...Yoksa Identity tablolarınızı acsa bile onun işlemlerini kullanamazsınız...Yani DI Identity icin calısmaz...Sadece tablolar acılmıs olur...

            builder.Populate(ni); //böylece Identity'niz builder nesnenize eklenmiş oluyor...

            builder.Register(c =>
            {

                IConfiguration config = c.Resolve<IConfiguration>();

                DbContextOptionsBuilder<MyContext> opt = new DbContextOptionsBuilder<MyContext>();

                opt.UseSqlServer(config.GetSection("ConnectionStrings:MyConnection").Value).UseLazyLoadingProxies();

                return new MyContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();




        }
    }
}
