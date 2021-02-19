using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.DALModel;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Context
{
    //Eger kurmak istediginiz VeriTabanı yapısında Identity kullanacaksanız iseni DbContext'ten miras almamalısınız...Cünkü Identity kendi tablolar tamamen hazır  bir yapı suna ve bu hazır yapıyı DbContext saglayamaz... Miras alacagınız sınıf IdentityDbContext olmalıdır
    public class MyContext:IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        //Custom olarak Identity'e eklemek istediginiz sınıfları DbSet olarak burada da olusturmayı unutmayın!!!
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }



    }
}
