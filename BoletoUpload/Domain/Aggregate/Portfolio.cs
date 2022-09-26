using TradingUpload.Domain.Entity;

namespace TradingUpload.Domain.Aggregate
{
    public class Portfolio
    {
        public Portfolio()
        {
            Boletos = new List<Boleto>();
        }

        public string CustomerCode { get; private set; }
        public List<Boleto> Boletos { get; private set; }


        public Portfolio SetCustomerCode(string customerCode)
        {
            CustomerCode = customerCode;
            return this;
        }

        public Portfolio AddBoleto(Boleto trade)
        {
            Boletos.Add(trade);
            return this;
        }

        public void SetDiscount()
        {
            Boletos.OrderByDescending(x => x.OperationFinancialValue).Where(x => x.IsValid).First().SetDiscount();
        }
    }
}
