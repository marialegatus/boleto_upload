namespace BoletoUpload.Specification.Interface
{
    public interface ICheckIfStockExchangeIdIsValid
    {
        bool IsSatisfiedBy(string stockExchangeId);
    }
}
