using BoletoUpload.Infrastructure.Repository;
using BoletoUpload.Infrastructure.Interface;
using BoletoUpload.Specification.Interface;
using BoletoUpload.Application.Interface;
using BoletoUpload.Specification;
using BoletoUpload.Application;

namespace BoletoUpload.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBoletoAppService, BoletoAppService>();

            services.AddScoped<ICheckIfAssetCodeIsValid, CheckIfAssetCodeIsValid>();
            services.AddScoped<ICheckIfBrokerIsValid, CheckIfBrokerIsValid>();
            services.AddScoped<ICheckIfCustomerCodeIsValid, CheckIfCustomerCodeIsValid>();
            services.AddScoped<ICheckIfStockExchangeIdIsValid, CheckIfStockExchangeIdIsValid>();

            services.AddSingleton<IBoletoRepository, BoletoRepository>();
        }
    }
}
