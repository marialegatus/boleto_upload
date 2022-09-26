using TradingUpload.Specification.Interface;
using TradingUpload.Application.Interface;
using TradingUpload.Application.ViewModel;
using TradingUpload.Application.Adapter;
using TradingUpload.Application.DTO;
using TradingUpload.Domain.Aggregate;

namespace TradingUpload.Application
{
    public class BoletoAppService : IBoletoAppService
    {
        private readonly ICheckIfAssetCodeIsValid _checkIfAssetCodeIsValid;
        private readonly ICheckIfBrokerIsValid _checkIfBrokerIsValid;
        private readonly ICheckIfCustomerCodeIsValid _checkIfCustomerCodeIsValid;
        private readonly ICheckIfStockExchangeIdIsValid _checkIfStockExchangeIdIsValid;

        private readonly string _fileStart;
        private readonly string _fileEnd;
        private readonly string _fileSeparator;
        public BoletoAppService(IConfiguration configuration, ICheckIfAssetCodeIsValid checkIfAssetCodeIsValid, ICheckIfBrokerIsValid checkIfBrokerIsValid,
            ICheckIfCustomerCodeIsValid checkIfCustomerCodeIsValid, ICheckIfStockExchangeIdIsValid checkIfStockExchangeIdIsValid)
        {
            _fileStart = configuration.GetValue<string>("FileConfig:Start");
            _fileEnd = configuration.GetValue<string>("FileConfig:End");
            _fileSeparator = configuration.GetValue<string>("FileConfig:Separator");

            _checkIfAssetCodeIsValid = checkIfAssetCodeIsValid;
            _checkIfBrokerIsValid = checkIfBrokerIsValid;
            _checkIfCustomerCodeIsValid = checkIfCustomerCodeIsValid;
            _checkIfStockExchangeIdIsValid = checkIfStockExchangeIdIsValid;
        }
        public async Task<IEnumerable<PortfolioView>> AnalyseBoleto(IFormFile file)
        {
            List<Portfolio> listAggregate = new List<Portfolio>();

            var boletos = file.ToListDTO(_fileStart, _fileEnd, _fileSeparator);

            foreach (var boletoDTO in boletos)
            {
                var boleto = boletoDTO.ToEntity();
                Portfolio portfolio = new Portfolio();


                var hasValidCustomerCode = _checkIfCustomerCodeIsValid.IsSatisfiedBy(boletoDTO.CustomerCode);
                if (!hasValidCustomerCode)
                {
                    boleto.SetValidationError("Invalid Customer code informed");
                }

                var hasValidStockExchange = _checkIfStockExchangeIdIsValid.IsSatisfiedBy(boletoDTO.StockExchangeId);
                if (!hasValidStockExchange)
                {
                    boleto.SetValidationError("Invalid Stock Exchange Id informed");
                }

                var hasValidBroker = _checkIfBrokerIsValid.IsSatisfiedBy(boletoDTO.Broker);
                if (!hasValidBroker)
                {
                    boleto.SetValidationError("Invalid Broker informed");
                }

                var hasValidAssetCode = _checkIfAssetCodeIsValid.IsSatisfiedBy(boletoDTO.AssetCode);
                if (!hasValidAssetCode)
                {
                    boleto.SetValidationError("Invalid Asset code informed");
                }

                if (listAggregate.FirstOrDefault(x => x.CustomerCode is null || x.CustomerCode.Equals(boletoDTO.CustomerCode)) is null)
                {
                    portfolio = new Portfolio().SetCustomerCode(boletoDTO.CustomerCode);
                    portfolio.AddBoleto(boleto);
                    listAggregate.Add(portfolio);
                }
                else
                {
                    listAggregate.Find(x => x.CustomerCode is null || x.CustomerCode.Equals(boletoDTO.CustomerCode)).AddBoleto(boleto);
                }
            }

            return listAggregate.ToEnumerableView();
        }
    }
}
