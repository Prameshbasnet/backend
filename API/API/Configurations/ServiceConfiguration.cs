using API.Data;
using API.Data.Contracts;
using API.Models.Categories;
using API.Models.Categories.Contracts;
using API.Models.Feedbacks;
using API.Models.Feedbacks.Contracts;
using API.Models.FileUploads;
using API.Models.FileUploads.Contracts;
using API.Models.Foods;
using API.Models.Foods.Contracts;
using API.Models.PromoCodes;
using API.Models.PromoCodes.Contracts;
using API.Models.Stocks;
using API.Models.Stocks.Contracts;
using API.Models.Tables;
using API.Models.Tables.Contracts;
using Common.Common.Handlers;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<APIDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("AppConnectionString")));

            services.AddTransient<GlobalExceptionHandler>(provider =>
            {
                var env = provider.GetRequiredService<IHostEnvironment>();
                var logger = provider.GetRequiredService<ILogger<GlobalExceptionHandler>>();
                var serviceName = "API";
                return new GlobalExceptionHandler(env, logger, serviceName);
            });

            services.AddCors(opt =>
               opt.AddPolicy("AllowAll",
                  builder =>
                  {
                      builder.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                  })
           );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPromoCodeService, PromoCodeService>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IStockService, StockService>();
        }
    }
}
