using BussinessLayer.AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Reposatories;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace JSB_Project.HelperClasses
{
    public static class Service
    {
        public static WebApplicationBuilder DbConnection(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseLazyLoadingProxies()
               .UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
               b => b.MigrationsAssembly("JSB_Project"));
            });
            return builder;
        }
        public static WebApplicationBuilder ConfigrationService(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProduct, ProductReposatory>();
            builder.Services.AddScoped<IOrder, OrderReposatory>();
            return builder;
        }
        public static WebApplicationBuilder ConfigrationAutomapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            return builder;
        }
    }
}
