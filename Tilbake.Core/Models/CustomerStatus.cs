using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class CustomerStatus
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public bool? IsVisible { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<PortfolioCustomer> PortfolioCustomers { get; set; } = new List<PortfolioCustomer>();
}
