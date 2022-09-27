namespace BoletoUpload.Application.ViewModel
{
    public class BoletoView
    {
        public string Date { get; set; }
        public string OperationType { get; set; }
        public string StockExchangeId { get; set; }
        public string AssetCode { get; set; }
        public string Broker { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal ?OperationFinancialValue { get; set; }
        public decimal ?OperationDiscountValue { get; set; }
        public string BoletoStatus { get; set; }

        public string ErrorMessage { get; set; }
    }
}
