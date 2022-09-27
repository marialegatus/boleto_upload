namespace BoletoUpload.Specification.Interface
{
    public interface ICheckIfAssetCodeIsValid
    {
        bool IsSatisfiedBy(string assetCode);
    }
}
