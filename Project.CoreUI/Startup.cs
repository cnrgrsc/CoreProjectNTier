using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.BLL.ServiceExtensions;


namespace Project.CoreUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();
            services.AddAuthentication();
            //Manual Extension yaptıgımızda kullanacagımız yöntemin icerisindeki metotları tetiklemek
            //services.AddRepAndManServices(); //=> Extension metodumuz ile servisimizi kullanmak
            //services.AddDbContextService();
            //services.AddIdentityService();

           

            //Normal (N-Layered olmayan normal projelerde) Dependency Injection yapısı Core'da su sekilde kurulur

            //Core'un otomatik olarak hangi Interface'i nasıl algılayacagını belirten bir mimarisi vardır...Bu sisteme sizin özellikle bir nesne göndermenize gerek yoktur bu otomatik yapılır. Ancak hangi Interface'in olacagını belirtmelisiniz...
            #region AddScoped
            //services.AddScoped<IProductRepository,ProductRepository>().;

            /*
             
             
             public IActionResult Deneme(IProductRepository item , IProductRepository item2)
            {
            
                return View();
            }
             
             
             
             
             */

            #endregion



            //services.AddSingleton<IProductRepository,ProductRepository>().;


            #region AddTransient
            //services.AddTransient<IProductRepository,ProductRepository>(); 

            //Her sınıf tetiklenişi icin ayrı bir instance alır


            /*
             
            public IActionResult Deneme(IProductRepository item,IProductRepository item2)
            {

            }
             
             
             */




            #endregion



            //Yukarıdaki demek istedigimiz şey proje bir yerde IProductRepository gördügünde ona nesne olarak ne göndermeli onu söylemektir...Dikkat ederseniz burada instance alma işlemini bile siz yapmıyorsunuz... Bu instance alma işlemi Dependency Injection'ın Core'da otomatik olarak entegre edilmesiyle gercekleşiyor...AddSingleton ilgili nesne icin bir SingletonPattern görevi görürken,AddScoped bir HTTPRequest'i icin sadece bir nesne alma görevi görürken,AddTransient her class tetiklendiginde bir nesne yaratan bir Dependenjy Injection işlemi yapar...

            // Eger katmanlı bir yapı kuruyorsanız bu AddTransient olayını kendi mimarinize göre şekillendirmek zorundasınız...Bunun iki yöntemi vardır...Ya Autofac kütüphanesi kullanarak Injection Extension yapmak (Yani Injection'ı genişletmek) veya kendi Extension metodunuzu static sınıfta yaratarak bu Injection Extension'i manual yapmak...





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=CategoryList}/{id?}");
            });
        }
    }
}
