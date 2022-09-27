using BoletoUpload.Infrastructure.Model;
using BoletoUpload.Domain.Entity;

namespace BoletoUpload.Infrastructure.Adapter
{
    public static class BoletoAdapter
    {
        public static ProcessedBoleto ToModel(this Boleto model, string customerCode)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var error = String.IsNullOrEmpty(model.ErrorMessage) ? "NOERROR" : model.ErrorMessage;

            var result = new ProcessedBoleto()
            {
                Date = model.Date,
                CustomerCode = customerCode,
                OperationType = model.OperationType.ToString(),
                StockExchangeId = model.StockExchangeId,
                AssetCode = model.AssetCode,
                Broker = model.Broker,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                OperationFinancialValue = model.OperationFinancialValue,
                OperationDiscountValue = model.OperationDiscountValue is null ? 0 : model.OperationDiscountValue,
                Status = model.Status.ToString(),
                ErrorMessage = error
            };

            return result;
        }
    }
}
