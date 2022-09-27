using System.ComponentModel.DataAnnotations;

namespace BoletoUpload.Domain.Enum
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
