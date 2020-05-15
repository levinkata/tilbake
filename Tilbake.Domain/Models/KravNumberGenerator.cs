using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.Domain.Models
{
    public class KravNumberGenerator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KravNumber { get; set; }
    }
}
