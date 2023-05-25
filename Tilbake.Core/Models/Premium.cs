using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Premium
{
    public Guid Id { get; set; }

    public Guid PolicyId { get; set; }

    public DateTime PremiumDate { get; set; }

    public int PremiumMonth { get; set; }

    public int PremiumYear { get; set; }

    public decimal Amount { get; set; }

    public bool IsRefunded { get; set; }

    public decimal Commission { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal PolicyFee { get; set; }

    public decimal AdministrationFee { get; set; }

    public decimal Motor { get; set; }

    public decimal NonMotor { get; set; }

    public decimal MotorCommission { get; set; }

    public decimal NonMotorCommission { get; set; }

    public decimal CommissionTax { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Policy Policy { get; set; } = null!;
}
