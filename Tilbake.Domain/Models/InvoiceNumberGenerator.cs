using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.Domain.Models
{
    public class InvoiceNumberGenerator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceNumber { get; set; }
    }
}
