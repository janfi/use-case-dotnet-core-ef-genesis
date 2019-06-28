using rest_api.domain;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rest_api.identities
{
    public class Contact: BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();

        public static ContactModel toModel(Contact entity)
        {
            return new ContactModel
            {
                ContactId = entity.ContactId,
                Contracts = entity.Contracts.Select(c => Contract.toModel(c)).ToList(),
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate,
                Address = Address.toModel(entity.Address),
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }

        public static Contact formModel(ContactModel address)
        {
            return new Contact
            {
                ContactId = address.ContactId,
                Contracts = address.Contracts.Select(c => Contract.formModel(c)).ToList(),
                UpdatedDate = address.UpdatedDate,
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate,
                Address = Address.formModel(address.Address),
                FirstName = address.FirstName,
                LastName = address.LastName
            };
        }
    }
}
