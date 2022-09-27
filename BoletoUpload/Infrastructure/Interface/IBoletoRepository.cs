using BoletoUpload.Infrastructure.Model;
using BoletoUpload.Application.DTO;

namespace BoletoUpload.Infrastructure.Interface
{
    public interface IBoletoRepository
    {
        void InsertUpload(BoletoDTO model);
        void InsertProcessedUpload(ProcessedBoleto model);
    }
}
