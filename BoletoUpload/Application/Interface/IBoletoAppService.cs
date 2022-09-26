using TradingUpload.Application.ViewModel;

namespace TradingUpload.Application.Interface
{
    public interface IBoletoAppService
    {
        Task<IEnumerable<PortfolioView>> AnalyseBoleto(IFormFile file);
    }
}
