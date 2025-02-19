using API.Data;
using API.Data.Contracts;
using API.Models.Feedbacks;
using API.Models.Feedbacks.Contracts;
using API.Models.FileUploads;
using API.Models.FileUploads.Contracts;
using API.Models.PromoCodes;
using API.Models.PromoCodes.Contracts;
using Common.Common.Handlers;

namespace API.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<GlobalExceptionHandler>(provider =>
            {
                var env = provider.GetRequiredService<IHostEnvironment>();
                var logger = provider.GetRequiredService<ILogger<GlobalExceptionHandler>>();
                var serviceName = "API";
                return new GlobalExceptionHandler(env, logger, serviceName);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPromoCodeService, PromoCodeService>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
        }
    }
}
