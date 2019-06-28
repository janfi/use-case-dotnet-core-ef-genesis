using rest_api.dto;
using System.Linq;
using System.Collections.Generic;

namespace rest_api.domain
{
    public class ContactModel: BaseClassModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel Address { get; set; }

        public List<ContractModel> Contracts { get; set; } = new List<ContractModel>();

        public static ContactDTO toDTO(ContactModel entity)
        {
            return new ContactDTO
            {
                ContactId = entity.ContactId,
                Contracts = entity.Contracts.Select(c => ContractModel.toDTO(c)).ToList(),
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate,
                Address = AddressModel.toDTO(entity.Address),
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }

        public static ContactModel formDTO(ContactDTO address)
        {
            return new ContactModel
            {
                ContactId = address.ContactId,
                Contracts = address.Contracts.Select(c => ContractModel.formDTO(c)).ToList(),
                UpdatedDate = address.UpdatedDate,
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate,
                Address = AddressModel.formDTO(address.Address),
                FirstName = address.FirstName,
                LastName = address.LastName
            };
        }

    }
}
