using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Driver
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Guid OccupationId { get; set; }

    public DateTime? BirthDate { get; set; }

    public Guid GenderId { get; set; }

    public Guid MaritalStatusId { get; set; }

    public string LicenceNumber { get; set; } = null!;

    public DateTime LicenceDate { get; set; }

    public string LicenceIssuePlace { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual MaritalStatus MaritalStatus { get; set; } = null!;

    public virtual ICollection<MotorDriver> MotorDrivers { get; set; } = new List<MotorDriver>();

    public virtual Occupation Occupation { get; set; } = null!;
}
