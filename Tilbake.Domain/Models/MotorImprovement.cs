using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.Domain.Models
{
    public class MotorImprovement
    {
        public Guid ID { get; set; }
        public Guid MotorID { get; set; }

        [Display(Name = "Name"), Required, StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Description"), Required, StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "Factory Fitted"), Required, StringLength(50)]
        public bool FactoryFitted { get; set; }

        [Display(Name = "Make/Model"), Required, StringLength(50)]
        public string MakeModel { get; set; }

        [Display(Name = "Serial Number"), Required, StringLength(50)]
        public string SerialNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Value"), Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Display(Name = "Premium"), Column(TypeName = "decimal(18,2)")]
        public decimal Premium { get; set; }

        public virtual Motor Motor { get; private set; }
    }
}
