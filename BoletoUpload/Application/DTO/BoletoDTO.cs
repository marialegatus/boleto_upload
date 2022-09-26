namespace TradingUpload.Application.DTO
{
    public class BoletoDTO
    {
        public DateTime Date { get; set;  }
        public string CustomerCode { get; set; }
        public string Type { get; set; }
        public string StockExchangeId { get; set; }
        public string AssetCode { get; set; }
        public string Broker { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
