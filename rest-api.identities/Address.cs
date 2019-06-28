using rest_api.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.identities
{

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public static AddressModel toModel(Address entity)
        {
            return new AddressModel
            {
                City = entity.City,
                Street = entity.Street
            };
        }

        public static Address formModel(AddressModel address)
        {
            return new Address
            {
                City = address.City,
                Street = address.Street
            };
        }
    }

   
}
