using BoletoUpload.Domain.Aggregate.Builder;
using BoletoUpload.Domain.Validation;
using BoletoUpload.Domain.Enum;

namespace BoletoUpload.Domain.Entity
{
    public class Boleto : SeedWork.Entity
    {
        public Boleto(BoletoBuilder builder)
        {
            Date = builder.Date;
            OperationType = builder.OperationType;
            StockExchangeId = builder.StockExchangeId;
            AssetCode = builder.AssetCode;
            Broker = builder.Broker;
            Quantity = builder.Quantity;
            UnitPrice = builder.UnitPrice;
            SetOperationFinancialValue();
            Validate();
        }

        public DateTime Date { get; }
        public OperationType OperationType { get; }
        public string ?StockExchangeId { get; }
        public string ?AssetCode { get; }
        public string ?Broker { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }

        public decimal OperationFinancialValue { get; private set; }
        public decimal ?OperationDiscountValue { get; private set; }
        public Status Status { get; private set; }

        public string ?ErrorMessage { get; private set; }

        public bool IsValid { get; private set; }


        private void SetOperationFinancialValue()
        {
            OperationFinancialValue = Quantity * UnitPrice;
        }

        public void SetDiscount()
        {
            var discount = OperationFinancialValue * (0.1M);
            OperationDiscountValue = OperationFinancialValue - discount;
        }

        public void SetValidationError(string errorMessage)
        {
            Status = Status.ERRO;
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                ErrorMessage = errorMessage;
            }
            else
            {
                ErrorMessage = ErrorMessage + ", " + errorMessage;
            }
            
            IsValid = false;
        }

        protected override void Validate()
        {
            ValidationResult = new BoletoValidation().Validate(this);
            IsValid = ValidationResult.IsValid;
            if (!IsValid)
            {
                ErrorMessage = ValidationResult.ToString();
                Status = Status.ERRO;
            }
            else
            {
                Status = Status.OK;
            }
        }
    }
}
