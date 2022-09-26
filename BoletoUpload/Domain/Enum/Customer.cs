using System.ComponentModel.DataAnnotations;

namespace TradingUpload.Domain.Enum
{
    public enum Customer
    {
        [Display(Name = "CARTEIRA CLIENTE A")]
        CARTEIRACLIENTEA,
        [Display(Name = "CARTEIRA CLIENTE B")]
        CARTEIRACLIENTEB,
        [Display(Name = "CARTEIRA CLIENTE C")]
        CARTEIRACLIENTEC
    }
}
