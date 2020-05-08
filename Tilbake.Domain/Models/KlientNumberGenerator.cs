using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.Domain.Models
{
    public class KlientNumberGenerator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KlientNumber { get; set; }
    }
}
