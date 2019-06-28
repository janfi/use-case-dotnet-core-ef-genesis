
using rest_api.dto;

namespace rest_api.domain
{
    public class EntityModel: BaseClassModel
    {
        public int EntityId { get; set; }
        public AddressModel Address { get; set; }
        public bool isSiegeCentral { get; set; }

        public int EntrepriseId { get; set; }
        public EntrepriseModel Entreprise { get; set; }

        public static EntityDTO toDTO(EntityModel entity)
        {
            return new EntityDTO
            {
                Address = AddressModel.toDTO(entity.Address),
                EntityId = entity.EntityId,
                EntrepriseId = entity.EntrepriseId,
                isSiegeCentral = entity.isSiegeCentral,
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate

            };
        }

        public static EntityModel formDTO(EntityDTO address)
        {
            return new EntityModel
            {
                Address = AddressModel.formDTO(address.Address),
                EntityId = address.EntityId,
                EntrepriseId = address.EntrepriseId,
                isSiegeCentral = address.isSiegeCentral,
                UpdatedDate = address.UpdatedDate,
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate
            };
        }
    }
}
