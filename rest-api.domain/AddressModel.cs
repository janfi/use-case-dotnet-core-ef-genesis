
using rest_api.dto;

namespace rest_api.domain
{

    public class AddressModel
    {
        public string Street { get; set; }
        public string City { get; set; }

        public static AddressDTO toDTO(AddressModel entity)
        {
            return new AddressDTO
            {
                City = entity.City,
                Street = entity.Street
            };
        }

        public static AddressModel formDTO(AddressDTO address)
        {
            return new AddressModel
            {
                City = address.City,
                Street = address.Street
            };
        }
    }
}
