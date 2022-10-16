using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Client.Handlers;


namespace Client
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

            services.AddScoped<ICreateFridgeHandler, CreateFridgeHandler>();
            services.AddScoped<IUpdateFridgeHandler, UpdateFridgeHandler>();
            services.AddScoped<IUpdateProductHandler, UpdateProductHandler>();
            services.AddScoped<IDeleteFridgeHandler, DeleteFridgeHandler>();
            services.AddScoped<IDeleteProductHandler, DeleteProductHandler>();
            services.AddScoped<IGetFridgesHandler, GetFridgesHandler>();
            services.AddScoped<IGetProductsHandler, GetProductsHandler>();
            
            services.AddScoped<ICreateProductsHandler, CreateProductsHandler>();

            services.AddScoped<IGetFridgeByIdHandler, GetFridgeByIdHandler>();
            services.AddScoped<IGetProductByIdHandler, GetProductByIdHandler>();
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
                app.UseExceptionHandler("/Fridge/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Fridge}/{action=Index}/{id?}");
            });
        }
    }
}