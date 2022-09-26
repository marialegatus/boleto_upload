using FluentValidation.Results;

namespace TradingUpload.Domain.SeedWork
{
    public abstract class Entity
    {
        public ValidationResult? ValidationResult { get; set; }
        protected abstract void Validate();
    }
}
