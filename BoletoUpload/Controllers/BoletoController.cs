using TradingUpload.Application.ViewModel;
using TradingUpload.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace TradingUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoAppService _boletoAppService;

        public BoletoController(IBoletoAppService boletoAppService)
        {
            _boletoAppService = boletoAppService; 
        }

        [HttpPost(Name = "Upload")]
        [ProducesResponseType(200, Type = typeof(BoletoView))]
        [ProducesResponseType(400, Type = typeof(BoletoView))]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {

            var result = await _boletoAppService.AnalyseBoleto(file);
            return Ok(result);
        }
    }
}
