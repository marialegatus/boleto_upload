using BoletoUpload.Application.ViewModel;

namespace BoletoUpload.Application.Interface
{
    public interface IBoletoAppService
    {
        Task<IEnumerable<PortfolioView>> AnalyseBoleto(IFormFile file);
    }
}
