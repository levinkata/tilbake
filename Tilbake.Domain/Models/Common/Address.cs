using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models.Common
{
    public class Address : ValueObject
    {
        public string PhysicalAddress { get; }
        public string PostalAddress { get; }
        public Guid CityId { get; }
        public virtual City City { get; }

        private Address()
        {
            
        }

        public Address(string physicalAddress, string postalAddress, Guid cityId)
        {
            PhysicalAddress = physicalAddress;
            PostalAddress = postalAddress;
            CityId = cityId;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return PhysicalAddress;
            yield return PostalAddress;
            yield return CityId; 
        }        
    }
}