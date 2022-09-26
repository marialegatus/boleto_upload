namespace TradingUpload.Specification.Interface
{
    public interface ICheckIfStockExchangeIdIsValid
    {
        bool IsSatisfiedBy(string stockExchangeId);
    }
}
