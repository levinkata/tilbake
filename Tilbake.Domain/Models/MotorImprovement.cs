using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class MotorImprovement
    {
        public Guid Id { get; set; }
        public Guid MotorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool FactoryFitted { get; set; }
        public string MakeModel { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Value { get; set; }
        public decimal Premium { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
