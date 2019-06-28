
namespace rest_api.dto
{
    public class EntityDTO: BaseClassDTO
    {

        public int EntityId { get; set; }
        public AddressDTO Address { get; set; }
        public bool isSiegeCentral { get; set; }
        public int EntrepriseId { get; set; }

    }
}
