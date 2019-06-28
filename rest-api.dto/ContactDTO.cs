using System;
using System.Collections.Generic;

namespace rest_api.dto
{
    public class ContactDTO: BaseClassDTO
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }

        public List<ContractDTO> Contracts { get; set; } = new List<ContractDTO>();
        

    }
}
