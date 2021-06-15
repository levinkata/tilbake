﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Clients = new HashSet<Client>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}