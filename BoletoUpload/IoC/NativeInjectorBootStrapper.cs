using TradingUpload.Specification.Interface;
using TradingUpload.Application.Interface;
using TradingUpload.Specification;
using TradingUpload.Application;

namespace TradingUpload.IoC
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
        }
    }
}
