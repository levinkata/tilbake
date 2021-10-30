using System.ComponentModel.DataAnnotations;

namespace Tilbake.Core.Enums
{
    public enum  AuditType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Create")]            
        Create = 1,
        
        [Display(Name = "Update")]
        Update = 2,

        [Display(Name = "Delete")]    
        Delete = 3
    }
}
