using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.Domain.Models
{
    public class PolitikkNumberGenerator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PolitikkNumber { get; set; }
    }
}
