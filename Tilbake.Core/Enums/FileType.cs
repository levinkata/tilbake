using System.ComponentModel.DataAnnotations;

namespace Tilbake.Core.Enums
{
    public enum FileType
    {
        [Display(Name = "Excel")]            
        Excel = 1,
        
        [Display(Name = "CSV")]
        CSV = 2,

        [Display(Name = "Fixed-Length Delimited")]    
        FixedLengthDelimited = 3
    }
}