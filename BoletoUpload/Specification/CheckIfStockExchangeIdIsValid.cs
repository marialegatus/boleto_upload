using TradingUpload.Specification.Interface;

namespace TradingUpload.Specification
{
    public class CheckIfStockExchangeIdIsValid : ICheckIfStockExchangeIdIsValid
    {
        private readonly IList<string> _stockExchanges;

        public CheckIfStockExchangeIdIsValid(IConfiguration configuration)
        {
            _stockExchanges = configuration.GetSection("StockExchanges").Get<IList<string>>();
        }

        public bool IsSatisfiedBy(string stockExchangeId)
        {
            var isSatisfiedBy = _stockExchanges.ToList().Exists(x => x.Equals(stockExchangeId));
            return isSatisfiedBy;
        }
    }
}
