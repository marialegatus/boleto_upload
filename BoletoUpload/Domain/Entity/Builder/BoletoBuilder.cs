using BoletoUpload.Domain.Entity;
using BoletoUpload.Domain.Enum;

namespace BoletoUpload.Domain.Aggregate.Builder
{
    public class BoletoBuilder
    {
        internal DateTime Date { get; private set; }
        internal OperationType OperationType { get; private set; }
        internal string ?StockExchangeId { get; private set; }
        internal string ?AssetCode { get; private set; }
        internal string ?Broker { get; private set; }
        internal int Quantity { get; private set; }
        internal decimal UnitPrice { get; private set; }

        public BoletoBuilder SetDate(DateTime date)
        {
            Date = date;
            return this;
        }

        public BoletoBuilder SetOperationType(OperationType operationType)
        {
            OperationType = operationType;
            return this;
        }

        public BoletoBuilder SetIds(string stockExchangeId)
        {
            StockExchangeId = stockExchangeId;
            return this;
        }

        public BoletoBuilder SetAssetCode(string assetCode)
        {
            AssetCode = assetCode;
            return this;
        }

        public BoletoBuilder SetBroker(string broker)
        {
            Broker = broker;
            return this;
        }

        public BoletoBuilder SetValues(int quantity, decimal unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            return this;
        }

        public Boleto Build()
        {
            return new Boleto(this);
        }
    }
}
