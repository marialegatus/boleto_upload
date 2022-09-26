using TradingUpload.Specification.Interface;

namespace TradingUpload.Specification
{
    public class CheckIfBrokerIsValid : ICheckIfBrokerIsValid
    {
        private readonly IList<string> _validBrokers;

        public CheckIfBrokerIsValid(IConfiguration configuration)
        {
            _validBrokers = configuration.GetSection("Brokers").Get<IList<string>>();
        }
        public bool IsSatisfiedBy(string broker)
        {
            var isSatisfiedBy = _validBrokers.ToList().Exists(x => x.Equals(broker));
            return isSatisfiedBy;
        }
    }
}
