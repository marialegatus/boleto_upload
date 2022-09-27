namespace BoletoUpload.Specification.Interface
{
    public interface ICheckIfCustomerCodeIsValid
    {
        bool IsSatisfiedBy(string customerCode);
    }
}
