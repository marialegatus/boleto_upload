using FluentValidation.Results;

namespace BoletoUpload.Domain.SeedWork
{
    public abstract class Entity
    {
        public ValidationResult? ValidationResult { get; set; }
        protected abstract void Validate();
    }
}
