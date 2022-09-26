using TradingUpload.Specification.Interface;

namespace TradingUpload.Specification
{
    public class CheckIfCustomerCodeIsValid : ICheckIfCustomerCodeIsValid
    {
        private readonly IList<string> _validCustomers;

        public CheckIfCustomerCodeIsValid(IConfiguration configuration)
        {
            _validCustomers = configuration.GetSection("CustomerCodes").Get<IList<string>>();
        }
        public bool IsSatisfiedBy(string customerCode)
        {
            var isSatisfiedBy = _validCustomers.ToList().Exists(x => x.Equals(customerCode));
            return isSatisfiedBy;
        }
    }
}
