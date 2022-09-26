using TradingUpload.Specification.Interface;

namespace TradingUpload.Specification
{
    public class CheckIfAssetCodeIsValid : ICheckIfAssetCodeIsValid
    {
        private readonly IList<string> _validAssetCodes;

        public CheckIfAssetCodeIsValid(IConfiguration configuration)
        {
            _validAssetCodes = configuration.GetSection("AssetCodes").Get<IList<string>>();
        }

        public bool IsSatisfiedBy(string assetCode)
        {
            var isSatisfiedBy = _validAssetCodes.ToList().Exists(x => x.Equals(assetCode));
            return isSatisfiedBy;
        }
    }
}
