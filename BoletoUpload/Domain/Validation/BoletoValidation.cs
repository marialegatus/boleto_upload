using FluentValidation;
using TradingUpload.Domain.Entity;

namespace TradingUpload.Domain.Validation
{
    public class BoletoValidation : AbstractValidator<Boleto>
    {

        public BoletoValidation()
        {
            ValidateOperationType();
            ValidateStockExchangeId();
            ValidateAssetCode();
            ValidateBroker();
            ValidateQuantity();
            ValidateUnitPrice();
        }

        protected void ValidateOperationType()
        {
            RuleFor(trade => trade.OperationType)
                .IsInEnum()
                .WithMessage("Invalid OperationType informed.");
        }

        protected void ValidateStockExchangeId()
        {
            RuleFor(trade => trade.StockExchangeId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid StockExchangeId informed.");
        }

        protected void ValidateAssetCode()
        {
            RuleFor(trade => trade.AssetCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid AssetCode informed.");
        }

        protected void ValidateBroker()
        {
            RuleFor(trade => trade.Broker)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Broker informed.");
        }

        protected void ValidateQuantity()
        {
            RuleFor(trade => trade.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0");
        }

        protected void ValidateUnitPrice()
        {
            RuleFor(trade => trade.UnitPrice)
                .GreaterThan(0)
                .WithMessage("UnitPrice must be greater than 0");
        }
    }
}
