using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.Domain.Models
{
    public class QuoteNumberGenerator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuoteNumber { get; set; }
    }
}
