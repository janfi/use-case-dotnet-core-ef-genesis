using System;
using System.Collections.Generic;


namespace rest_api.dto
{
    public class EntrepriseDTO : BaseClassDTO
    {
        public int EntrepriseId { get; set; }
        public string Name { get; set; }

        public string Tva { get; set; }

        public List<EntityDTO> Entities { get; set; } = new List<EntityDTO>();
        public List<ContractDTO> Contracts { get; set; } = new List<ContractDTO>();

    }
}
