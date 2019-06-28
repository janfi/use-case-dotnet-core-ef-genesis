using rest_api.dto;
using System.Linq;
using System.Collections.Generic;


namespace rest_api.domain
{
    public class EntrepriseModel : BaseClassModel
    {
        public int EntrepriseId { get; set; }
        public string Name { get; set; }

        public string Tva { get; set; }

        public List<EntityModel> Entities { get; set; } = new List<EntityModel>();
        public List<ContractModel> Contracts { get; set; } = new List<ContractModel>();

        public static EntrepriseDTO toDTO(EntrepriseModel entity)
        {
            return new EntrepriseDTO
            {
                EntrepriseId = entity.EntrepriseId,
                Name = entity.Name,
                Tva = entity.Tva,
                Contracts = entity.Contracts.Select(c => ContractModel.toDTO(c)).ToList(),
                Entities = entity.Entities.Select(e => EntityModel.toDTO(e)).ToList(),
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate,

            };
        }

        public static EntrepriseModel formDTO(EntrepriseDTO address)
        {
            return new EntrepriseModel
            {
                EntrepriseId = address.EntrepriseId,
                Name = address.Name,
                Tva = address.Tva,
                Contracts = address.Contracts.Select(c => ContractModel.formDTO(c)).ToList(),
                Entities = address.Entities.Select(e => EntityModel.formDTO(e)).ToList(),
                UpdatedDate = address.UpdatedDate,
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate,
            };
        }
    }
}
